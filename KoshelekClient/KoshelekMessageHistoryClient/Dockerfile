FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./KoshelekMessageHistoryClient.csproj", "./"]
WORKDIR /src
RUN dotnet restore "./KoshelekMessageHistoryClient.csproj"
COPY . .
RUN dotnet build "./KoshelekMessageHistoryClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KoshelekMessageHistoryClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8181:8080
ENTRYPOINT dotnet KoshelekMessageHistoryClient.dll