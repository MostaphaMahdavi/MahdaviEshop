#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Services/LoggingServices/LoggingServices.Api/LoggingServices.Api.csproj", "Src/Services/LoggingServices/LoggingServices.Api/"]
COPY ["Src/Services/LoggingServices/LoggingServices.Services/LoggingServices.Services.csproj", "Src/Services/LoggingServices/LoggingServices.Services/"]
COPY ["Src/Services/LoggingServices/LoggingServices.Repositories/LoggingServices.Repositories.csproj", "Src/Services/LoggingServices/LoggingServices.Repositories/"]
COPY ["Src/Services/LoggingServices/LoggingServices.DataAccessLayers/LoggingServices.DataAccessLayers.csproj", "Src/Services/LoggingServices/LoggingServices.DataAccessLayers/"]
COPY ["Src/Services/LoggingServices/LoggingServices.Domains/LoggingServices.Domains.csproj", "Src/Services/LoggingServices/LoggingServices.Domains/"]
COPY ["Src/Services/Frameworks/MahdaviEshop.Framework/MahdaviEshop.Framework.csproj", "Src/Services/Frameworks/MahdaviEshop.Framework/"]
RUN dotnet restore "Src/Services/LoggingServices/LoggingServices.Api/LoggingServices.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/LoggingServices/LoggingServices.Api"
RUN dotnet build "LoggingServices.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoggingServices.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoggingServices.Api.dll"]
