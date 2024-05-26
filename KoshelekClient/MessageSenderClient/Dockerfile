FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./MessageSenderClient.csproj", "./"]
WORKDIR /src
RUN dotnet restore "./MessageSenderClient.csproj"
COPY . .
RUN dotnet build "./MessageSenderClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessageSenderClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT dotnet MessageSenderClient.dll