FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CQRS.HomeBudget.WebApi/CQRS.HomeBudget.WebApi.csproj", "CQRS.HomeBudget.WebApi/"]
RUN dotnet restore "CQRS.HomeBudget.WebApi/CQRS.HomeBudget.WebApi.csproj"
COPY . .
WORKDIR "/src/CQRS.HomeBudget.WebApi"
RUN dotnet build "CQRS.HomeBudget.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CQRS.HomeBudget.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CQRS.HomeBudget.WebApi.dll"]