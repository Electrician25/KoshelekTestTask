#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./KoshelekWebServer/KoshelekWebServer.csproj", "./KoshelekWebServer/KoshelekWebServer.csproj"]
COPY ["./ApplicationDatase.DAL/ApplicationDatase.DAL.csproj", "./ApplicationDatase.DAL/ApplicationDatase.DAL.csproj"]
#CMD ["tail","-f","/dev/null"]
WORKDIR /src
RUN dotnet restore "./KoshelekWebServer/KoshelekWebServer.csproj"
COPY . .
RUN dotnet build "./KoshelekWebServer/KoshelekWebServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./KoshelekWebServer/KoshelekWebServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "KoshelekWebServer.dll"]