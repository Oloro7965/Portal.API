# ===============================
# STAGE 1: Build
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Portal.sln ./
COPY Portal.Application/Portal.Application.csproj Portal.Application/
COPY Portal.Core/Portal.Core.csproj Portal.Core/
COPY Portal.Infraestructure/Portal.Infraestructure.csproj Portal.Infraestructure/
COPY Portal.API/Portal.API.csproj Portal.API/

RUN dotnet restore Portal.sln
COPY . .
RUN dotnet publish Portal.API/Portal.API.csproj -c Release -o /app/publish

# ===============================
# STAGE 2: Runtime
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Instala ferramentas essenciais (ping, sqlcmd, ef)
RUN apt-get update && apt-get install -y \
    iputils-ping curl wget unixodbc-dev gnupg \
    && wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg \
    && mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg \
    && wget -qO- https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update && ACCEPT_EULA=Y apt-get install -y mssql-tools18 \
    && mkdir -p /root/.nuget/NuGet && mkdir -p /root/.dotnet/tools \
    && DOTNET_CLI_HOME=/root dotnet tool install --global dotnet-ef --version 8.* \
    && rm -rf /var/lib/apt/lists/*

ENV PATH="$PATH:/root/.dotnet/tools"

COPY --from=build /app/publish /app/publish

# Copia todos os .csproj necessários para o EF poder compilar dependências
COPY Portal.API/Portal.API.csproj /src/Portal.API/
COPY Portal.Application/Portal.Application.csproj /src/Portal.Application/
COPY Portal.Core/Portal.Core.csproj /src/Portal.Core/
COPY Portal.Infraestructure/Portal.Infraestructure.csproj /src/Portal.Infraestructure/
COPY Portal.sln /src/Portal.sln

COPY entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh

EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["/app/entrypoint.sh"]
