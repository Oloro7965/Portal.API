using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Portal.Application.Commands.CreateUserCommand;
using Portal.Application.Interfaces;
using Portal.Core.Repositories;
using Portal.Core.Service;
using Portal.Infraestructure;
using Portal.Infraestructure.Auth;
using Portal.Infraestructure.Persistance.Repositories;
using Portal.Infraestructure.Services;
using Portal.API.Services;
using System.Text;
using System.Text.Json;
using FluentValidation;
using MediatR;
using Portal.Application.Pipeline;
using Portal.Application.Validators;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddHttpClient();

// 🔹 Banco de dados
var connectionString = configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PortalDbContext>(options => options.UseSqlServer(connectionString));

// 🔹 MediatR e serviços da aplicação
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));
builder.Services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);

// Registrar pipeline de validao do MediatR
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped<IAuthService, AuthService>();

// 🔹 JWT Configuration
var jwtKey = configuration["Jwt:Key"];
if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new InvalidOperationException("Configuration value 'Jwt:Key' is missing or empty.");
}

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = signingKey
    };

    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("AuthToken"))
                context.Token = context.Request.Cookies["AuthToken"];
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { message = "Usuário não autenticado" });
            return context.Response.WriteAsync(result);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { message = "Você não tem permissão para acessar este recurso." });
            return context.Response.WriteAsync(result);
        }
    };
});

// 🔹 Repositórios e serviços
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IArtigoRepository, ArtigoRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IEventRepository, EventoRepository>();
builder.Services.AddScoped<IForumRepository, ForumRepository>();
builder.Services.AddScoped<IRevistaRepository, RevistaRepository>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
builder.Services.AddScoped<IKeywordsRepository, KeywordsRepository>();
builder.Services.AddScoped<IUrlGenerator, UrlGenerator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IArquivoArtigoService, ArquivoArtigoService>();
builder.Services.AddScoped<IArquivoRevistaService, ArquivoRevistaService>();

// 🔹 OpenAI Keyword Service
var openAIConfig = configuration.GetSection("OpenAI");
var apiKey = openAIConfig.GetValue<string>("ApiKey");
var model = openAIConfig.GetValue<string>("Model");
builder.Services.AddScoped<IKeywordService>(_ => new KeywordService(apiKey, model));

// 🔹 Controllers e limites de upload
builder.Services.AddControllers();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

// 🔹 Swagger & CORS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Política nomeada de CORS (suporta AllowCredentials)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DockerCors", policy =>
    {
        policy
            .WithOrigins(
                "http://portal:3000",         // nome do serviço frontend no Docker
                "http://localhost:3000",      // acesso local via browser
                "http://10.77.1.56:3000"      // IP da máquina virtual
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// ===================================================
// 🧩 MIGRAÇÕES AUTOMÁTICAS NO STARTUP
// ===================================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PortalDbContext>();
    try
    {
        Console.WriteLine("🚀 Verificando migrações pendentes...");
        db.Database.Migrate();
        Console.WriteLine("✅ Banco de dados atualizado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠️ Falha ao aplicar migrações: " + ex.Message);
    }
}

// ===================================================
// 🌐 PIPELINE HTTP (ordem é importante!)
// ===================================================

// Swagger (opcional, habilitado em todos os ambientes)
app.UseSwagger();
app.UseSwaggerUI();

// 🔹 CORS deve vir ANTES da autenticação
app.UseCors("DockerCors");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
