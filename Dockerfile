FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
# EXPOSE 80

COPY ["src/Two.MovieCatalog.Application/Two.MovieCatalog.Application.csproj", "./Two.MovieCatalog.Application/"]
COPY ["src/Two.MovieCatalog.Application.Contracts/Two.MovieCatalog.Application.Contracts.csproj", "./Two.MovieCatalog.Application.Contracts/"]
COPY ["src/Two.MovieCatalog.DbMigrator/Two.MovieCatalog.DbMigrator.csproj", "./Two.MovieCatalog.DbMigrator/"]
COPY ["src/Two.MovieCatalog.Domain/Two.MovieCatalog.Domain.csproj", "./Two.MovieCatalog.Domain/"]
COPY ["src/Two.MovieCatalog.Domain.Shared/Two.MovieCatalog.Domain.Shared.csproj", "./Two.MovieCatalog.Domain.Shared/"]
COPY ["src/Two.MovieCatalog.EntityFrameworkCore/Two.MovieCatalog.EntityFrameworkCore.csproj", "./Two.MovieCatalog.EntityFrameworkCore/"]
COPY ["src/Two.MovieCatalog.HttpApi/Two.MovieCatalog.HttpApi.csproj", "./Two.MovieCatalog.HttpApi/"]
COPY ["src/Two.MovieCatalog.HttpApi.Client/Two.MovieCatalog.HttpApi.Client.csproj", "./Two.MovieCatalog.HttpApi.Client/"]
COPY ["src/Two.MovieCatalog.HttpApi/Two.MovieCatalog.HttpApi.csproj", "./Two.MovieCatalog.HttpApi/"]
COPY ["src/Two.MovieCatalog.HttpApi.Host/Two.MovieCatalog.HttpApi.Host.csproj", "./Two.MovieCatalog.HttpApi.Host/"]

COPY ["src/common.props", "./"]

# .NET Core Restore
RUN dotnet restore "./Two.MovieCatalog.HttpApi.Host/Two.MovieCatalog.HttpApi.Host.csproj"

# Copy All Files
COPY src ./

# .NET Core Build and Publish
RUN dotnet publish "./Two.MovieCatalog.HttpApi.Host/Two.MovieCatalog.HttpApi.Host.csproj" -c Release -o /publish

FROM nginx:1.19
COPY ./nginx/nginx.conf /etc/nginx/nginx.conf

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./
ENTRYPOINT ["dotnet", "Two.MovieCatalog.HttpApi.Host.dll"]