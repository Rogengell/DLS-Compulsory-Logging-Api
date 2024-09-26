FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Health App Login/Health App Login.csproj", "Health App Login/"]
RUN dotnet restore "Health App Login/Health App Login.csproj"
COPY . .
WORKDIR "/src/Health App Login"
RUN dotnet build "Health App Login.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Health App Login.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Health App Login.dll"]
