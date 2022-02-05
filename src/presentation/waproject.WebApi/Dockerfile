#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/presentation/waproject.WebApi/waproject.WebApi.csproj", "src/presentation/waproject.WebApi/"]
COPY ["src/core/waproject.Application/waproject.Application.csproj", "src/core/waproject.Application/"]
COPY ["src/core/waproject.Domain/waproject.Domain.csproj", "src/core/waproject.Domain/"]
COPY ["src/infrastructure/waproject.Data/waproject.Data.csproj", "src/infrastructure/waproject.Data/"]
COPY ["src/infrastructure/waproject.Shared/waproject.Shared.csproj", "src/infrastructure/waproject.Shared/"]
RUN dotnet restore "src/presentation/waproject.WebApi/waproject.WebApi.csproj"
COPY . .
WORKDIR "/src/src/presentation/waproject.WebApi"
RUN dotnet build "waproject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "waproject.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "waproject.WebApi.dll"]