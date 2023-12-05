#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InTime.Keys/InTime.Keys.API.csproj", "InTime.Keys/"]
COPY ["InTime.Keys.Application/InTime.Keys.Application.csproj", "InTime.Keys.Application/"]
COPY ["InTime.Keys.Domain/InTime.Keys.Domain.csproj", "InTime.Keys.Domain/"]
COPY ["InTime.Keys.Infrastructure/InTime.Keys.Infrastructure.csproj", "InTime.Keys.Infrastructure/"]
COPY ["InTime.Keys.Persistence/InTime.Keys.Persistence.csproj", "InTime.Keys.Persistence/"]
RUN dotnet restore "./InTime.Keys/./InTime.Keys.API.csproj"
COPY . .
WORKDIR "/src/InTime.Keys"
RUN dotnet build "./InTime.Keys.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InTime.Keys.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InTime.Keys.API.dll"]