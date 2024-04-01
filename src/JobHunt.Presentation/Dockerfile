#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/JobHunt.Presentation/JobHunt.Presentation.csproj", "src/JobHunt.Presentation/"]
COPY ["src/JobHunt.Application/JobHunt.Application.csproj", "src/JobHunt.Application/"]
COPY ["src/JobHunt.Domain/JobHunt.Domain.csproj", "src/JobHunt.Domain/"]
COPY ["src/JobHunt.Infrastracture/JobHunt.Infrastracture.csproj", "src/JobHunt.Infrastracture/"]
RUN dotnet restore "./src/JobHunt.Presentation/JobHunt.Presentation.csproj"
COPY . .
WORKDIR "/src/src/JobHunt.Presentation"
RUN dotnet build "./JobHunt.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JobHunt.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobHunt.Presentation.dll"]