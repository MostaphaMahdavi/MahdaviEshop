#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Services/Products/Products.Api/Products.Api.csproj", "Src/Services/Products/Products.Api/"]
COPY ["Src/Services/Products/Products.Services/Products.Services.csproj", "Src/Services/Products/Products.Services/"]
COPY ["Src/Services/Products/Products.Repository/Products.Repository.csproj", "Src/Services/Products/Products.Repository/"]
COPY ["Src/Services/Products/Products.DataAccessLayer/Products.DataAccessLayer.csproj", "Src/Services/Products/Products.DataAccessLayer/"]
COPY ["Src/Services/Products/Products.Domain/Products.Domain.csproj", "Src/Services/Products/Products.Domain/"]
COPY ["Src/Services/Frameworks/MahdaviEshop.Framework/MahdaviEshop.Framework.csproj", "Src/Services/Frameworks/MahdaviEshop.Framework/"]
RUN dotnet restore "Src/Services/Products/Products.Api/Products.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/Products/Products.Api"
RUN dotnet build "Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.Api.dll"]
