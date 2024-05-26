FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./MessageSenderClient/MessageSenderClient.csproj", "./MessageSenderClient/MessageSenderClient.csproj"]
WORKDIR /src
RUN dotnet restore "./MessageSenderClient/MessageSenderClient.csproj"
COPY . .
RUN dotnet build "./MessageSenderClient/MessageSenderClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./MessageSenderClient/MessageSenderClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#EXPOSE 5000
ENTRYPOINT ["dotnet", "MessageSenderClient.dll"]