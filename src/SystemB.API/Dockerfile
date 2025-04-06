# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SystemB.API/SystemB.API.csproj", "src/SystemB.API/"]
COPY ["src/SystemB.Application/SystemB.Application.csproj", "src/SystemB.Application/"]
COPY ["src/Shared/Shared.csproj", "src/Shared/"]
COPY ["src/SystemA.Contracts/SystemA.Contracts.csproj", "src/SystemA.Contracts/"]
COPY ["src/SystemB.Domain/SystemB.Domain.csproj", "src/SystemB.Domain/"]
COPY ["src/SystemB.Infrastructure/SystemB.Infrastructure.csproj", "src/SystemB.Infrastructure/"]
RUN dotnet restore "./src/SystemB.API/SystemB.API.csproj"
COPY . .
WORKDIR "/src/src/SystemB.API"
RUN dotnet build "./SystemB.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SystemB.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SystemB.API.dll"]