#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY Arev.Ticketing.Consumer.Api/Arev.Ticketing.Consumer.Api.csproj Arev.Ticketing.Consumer.Api/
COPY Arev.Ticketing.Shared.Models/Arev.Ticketing.Shared.Models.csproj Arev.Ticketing.Shared.Models/
RUN dotnet restore "Arev.Ticketing.Consumer.Api/Arev.Ticketing.Consumer.Api.csproj"
COPY . .
WORKDIR "/src/Arev.Ticketing.Consumer.Api"
RUN dotnet build "Arev.Ticketing.Consumer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arev.Ticketing.Consumer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arev.Ticketing.Consumer.Api.dll"]
