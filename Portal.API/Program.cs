using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OpenAI;
using Portal.Application.Commands.CreateUserCommand;
using Portal.Core.Repositories;
using Portal.Core.Service;
using Portal.Infraestructure;
using Portal.Infraestructure.Auth;
using Portal.Infraestructure.Persistance.Repositories;
using Portal.Infraestructure.Services;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddHttpClient();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PortalDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));
builder.Services.AddScoped<IAuthService, AuthService>();
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
            {
                context.Token = context.Request.Cookies["AuthToken"];
            }
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { message = "Usu�rio n�o autenticado" });
            return context.Response.WriteAsync(result);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { message = "Voc� n�o tem permiss�o para acessar este recurso." });
            return context.Response.WriteAsync(result);
        }
    };
});
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IArtigoRepository, ArtigoRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IEventRepository, EventoRepository>();
builder.Services.AddScoped<IForumRepository,ForumRepository>();
builder.Services.AddScoped<IRevistaRepository, RevistaRepository>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
builder.Services.AddScoped<IKeywordsRepository, KeywordsRepository>();

builder.Services.AddSingleton(new OpenAIClient(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
));
builder.Services.AddScoped<IEmbeddingService, EmbeddingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
