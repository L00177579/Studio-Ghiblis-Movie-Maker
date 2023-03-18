#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG SONAR_PROJECT
ARG SONAR_ORG
ARG SONAR_LOGIN
ARG SONAR_HOST_URL

WORKDIR /src
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet tool install dotnet-sonarscanner --global
RUN dotnet tool install dotnet-coverage --global 
RUN apt-get update && apt-get dist-upgrade -y && apt-get install -y openjdk-11-jre

RUN dotnet sonarscanner begin /k:"$SONAR_PROJECT" /o:"$SONAR_ORG" /d:sonar.login="$SONAR_LOGIN" /d:sonar.host.url="$SONAR_HOST_URL" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
COPY . .
RUN dotnet restore "StudioGhibliMovieMaker.sln"
WORKDIR "/src/."
RUN dotnet build "StudioGhibliMovieMaker.sln" -c Release -o /app/build
RUN dotnet-coverage collect 'dotnet test' -f xml -o 'coverage.xml'
RUN dotnet sonarscanner end /d:sonar.login="$SONAR_LOGIN"

FROM build as testing
WORKDIR /src

FROM build AS publish
RUN dotnet publish "./StudioGhibliMovieMaker/StudioGhibliMovieMaker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudioGhibliMovieMaker.dll"]
