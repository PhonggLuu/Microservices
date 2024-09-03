#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
#USER app
WORKDIR /app
#EXPOSE 8080

#COPY csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

#copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out

#build runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebDockerProject.dll"]


#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["WebDocker/WebDocker.csproj", "WebDocker/"]
#RUN dotnet restore "./WebDocker/WebDocker.csproj"
#COPY . .
#WORKDIR "/src/WebDocker"
#RUN dotnet build "./WebDocker.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./WebDocker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WebDocker.dll"]