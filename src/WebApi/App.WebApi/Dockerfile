#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/WebApi/App.WebApi/App.WebApi.csproj", "src/WebApi/App.WebApi/"]
COPY ["src/Core/App.ApplicationCore/App.ApplicationCore.csproj", "src/Core/App.ApplicationCore/"]
COPY ["src/Infrastructure/App.Infrastructure/App.Infrastructure.csproj", "src/Infrastructure/App.Infrastructure/"]
RUN dotnet restore "src/WebApi/App.WebApi/App.WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi/App.WebApi"
RUN dotnet build "App.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.WebApi.dll"]
