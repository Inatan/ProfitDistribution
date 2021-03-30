#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR .
RUN apt-get update
RUN apt-get install -y locales locales-all
RUN update-locale LANG=pt_BR.UTF-8
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ProfitDistribution.Api/ProfitDistribution.Api.csproj", "src/ProfitDistribution.Api/"]
COPY ["src/ProfitDistribution.Domain/ProfitDistribution.Domain.csproj", "src/ProfitDistribution.Domain/"]
COPY ["src/ProfitDistribution.Services/ProfitDistribution.Services.csproj", "src/ProfitDistribution.Services/"]
COPY ["src/ProfitDistribution.Infrastructure/ProfitDistribution.Infrastructure.csproj", "src/ProfitDistribution.Infrastructure/"]
RUN dotnet restore "src/ProfitDistribution.Api/ProfitDistribution.Api.csproj"
COPY . .
WORKDIR "src/ProfitDistribution.Api"
RUN dotnet build "ProfitDistribution.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProfitDistribution.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfitDistribution.Api.dll"]