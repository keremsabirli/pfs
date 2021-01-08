FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY PFSS.API/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish PrivateFileStorageService.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PFSS.API.dll"]

#App exposed in 80 port
