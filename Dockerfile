FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ARG BUILD_ENV=Debug

WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c $BUILD_ENV -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Plexporter.Server.dll"]
