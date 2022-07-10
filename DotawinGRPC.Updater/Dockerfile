#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotawinGRPC.Updater/DotawinGRPC.Updater.csproj", "DotawinGRPC.Updater/"]
RUN dotnet restore "DotawinGRPC.Updater/DotawinGRPC.Updater.csproj"
COPY . .
WORKDIR "/src/DotawinGRPC.Updater"
RUN dotnet build "DotawinGRPC.Updater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotawinGRPC.Updater.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotawinGRPC.Updater.dll"]