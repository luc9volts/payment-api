FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY src/Web/web.csproj src/Web/
COPY src/ApplicationCore/ApplicationCore.csproj src/ApplicationCore/
COPY src/DataAccess/DataAccess.csproj src/DataAccess/
RUN dotnet restore src/Web/web.csproj
COPY . .
WORKDIR /src/src/Web
RUN dotnet build web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "web.dll"]
