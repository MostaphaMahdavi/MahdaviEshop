#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Services/Baskets/Baskets.Api/Baskets.Api.csproj", "Src/Services/Baskets/Baskets.Api/"]
COPY ["Src/Services/Baskets/Baskets.Services/Baskets.Services.csproj", "Src/Services/Baskets/Baskets.Services/"]
COPY ["Src/Services/Baskets/Baskets.Repositories/Baskets.Repositories.csproj", "Src/Services/Baskets/Baskets.Repositories/"]
COPY ["Src/Services/Baskets/Baskets.DataAccessLayers/Baskets.DataAccessLayers.csproj", "Src/Services/Baskets/Baskets.DataAccessLayers/"]
COPY ["Src/Services/Baskets/Baskets.Domains/Baskets.Domains.csproj", "Src/Services/Baskets/Baskets.Domains/"]
COPY ["Src/Services/Frameworks/MahdaviEshop.Framework/MahdaviEshop.Framework.csproj", "Src/Services/Frameworks/MahdaviEshop.Framework/"]
RUN dotnet restore "Src/Services/Baskets/Baskets.Api/Baskets.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/Baskets/Baskets.Api"
RUN dotnet build "Baskets.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Baskets.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Baskets.Api.dll"]
