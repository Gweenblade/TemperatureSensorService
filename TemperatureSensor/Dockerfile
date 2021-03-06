#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TemperatureSensor/TemperatureSensor.csproj", "TemperatureSensor/"]
COPY ["TemperatureSensor.Infrastructure.DatabaseUtility/TemperatureSensor.Infrastructure.DatabaseUtility.csproj", "TemperatureSensor.Infrastructure.DatabaseUtility/"]
COPY ["TemperatureSensor.Core/TemperatureSensor.Core.csproj", "TemperatureSensor.Core/"]
COPY ["TemperatureSensor.WebApi/TemperatureSensor.Infrastructure.WebApi.csproj", "TemperatureSensor.WebApi/"]
COPY ["TemperatureSensor.Models/TemperatureSensor.Models.csproj", "TemperatureSensor.Models/"]
RUN dotnet restore "TemperatureSensor/TemperatureSensor.csproj"
COPY . .
WORKDIR "/src/TemperatureSensor"
RUN dotnet build "TemperatureSensor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemperatureSensor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemperatureSensor.dll"]