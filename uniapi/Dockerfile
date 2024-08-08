FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Check if user 'app' exists before creating
RUN if ! id "app" &>/dev/null; then \
        adduser --disabled-password --gecos "" app && \
        chown -R app /app; \
    fi

USER app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["uniapi.csproj", "."]
RUN dotnet restore "./uniapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./uniapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./uniapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "uniapi.dll"]
