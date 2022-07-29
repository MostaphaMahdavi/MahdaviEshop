#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Services/Discounts/Discounts.Api/Discounts.Api.csproj", "Src/Services/Discounts/Discounts.Api/"]
COPY ["Src/Services/Discounts/Discounts.Services/Discounts.Services.csproj", "Src/Services/Discounts/Discounts.Services/"]
COPY ["Src/Services/Discounts/Discounts.Repositories/Discounts.Repositories.csproj", "Src/Services/Discounts/Discounts.Repositories/"]
COPY ["Src/Services/Discounts/Discounts.DataAccessLayers/Discounts.DataAccessLayers.csproj", "Src/Services/Discounts/Discounts.DataAccessLayers/"]
COPY ["Src/Services/Discounts/Discounts.Domains/Discounts.Domains.csproj", "Src/Services/Discounts/Discounts.Domains/"]
COPY ["Src/Services/Frameworks/MahdaviEshop.Framework/MahdaviEshop.Framework.csproj", "Src/Services/Frameworks/MahdaviEshop.Framework/"]
RUN dotnet restore "Src/Services/Discounts/Discounts.Api/Discounts.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/Discounts/Discounts.Api"
RUN dotnet build "Discounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discounts.Api.dll"]
