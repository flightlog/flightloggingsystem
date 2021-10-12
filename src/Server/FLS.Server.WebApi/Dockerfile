#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApi/FLS.Server.WebApi/FLS.Server.WebApi.csproj", "WebApi/FLS.Server.WebApi/"]
COPY ["Data/FLS.Data.WebApi/FLS.Data.WebApi.csproj", "Data/FLS.Data.WebApi/"]
RUN dotnet restore "WebApi/FLS.Server.WebApi/FLS.Server.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi/FLS.Server.WebApi"
RUN dotnet build "FLS.Server.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FLS.Server.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FLS.Server.WebApi.dll"]