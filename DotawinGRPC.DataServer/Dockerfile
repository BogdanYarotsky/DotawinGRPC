#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotawinGRPC.DataServer/DotawinGRPC.DataServer.csproj", "DotawinGRPC.DataServer/"]
RUN dotnet restore "DotawinGRPC.DataServer/DotawinGRPC.DataServer.csproj"
COPY . .
WORKDIR "/src/DotawinGRPC.DataServer"
RUN dotnet build "DotawinGRPC.DataServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotawinGRPC.DataServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotawinGRPC.DataServer.dll"]