#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PrivateFileStorageService/PrivateFileStorageService.csproj", "PrivateFileStorageService/"]
RUN dotnet restore "PrivateFileStorageService/PrivateFileStorageService.csproj"
COPY . .
WORKDIR "/src/PrivateFileStorageService"
RUN dotnet build "PrivateFileStorageService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrivateFileStorageService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrivateFileStorageService.dll"]