#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trash_Collector/Trash_Collector.csproj", "Trash_Collector/"]
RUN dotnet restore "Trash_Collector/Trash_Collector.csproj"
COPY . .
WORKDIR "/src/Trash_Collector"
RUN dotnet build "Trash_Collector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trash_Collector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trash_Collector.dll"]