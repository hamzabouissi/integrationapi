FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IntegrationsAPI/IntegrationsAPI.csproj", "IntegrationsAPI/"]
RUN dotnet restore "IntegrationsAPI/IntegrationsAPI.csproj"
COPY . .
WORKDIR "/src/IntegrationsAPI"
RUN dotnet build "IntegrationsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationsAPI.dll"]
