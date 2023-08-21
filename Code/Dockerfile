#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MG.Application/MG.Application.csproj", "MG.Application/"]
COPY ["MG.Console/MG.Console.csproj", "MG.Console/"]
RUN dotnet restore "MG.Application/MG.Application.csproj"

COPY ["MG.Application", "MG.Application"]
COPY ["MG.Console", "MG.Console"]

WORKDIR "/src/MG.Console"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MG.Console.dll"]
