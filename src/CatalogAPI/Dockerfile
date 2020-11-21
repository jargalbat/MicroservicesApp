#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#Dockerfile is briefly the configuration files created for the each image and it is including dependencies.
#Alos it is including what to do and when building this docker image into the application.
#After the image created the container containing these image can be started.
#That is the configuration according to make dockerize the Web API project.

#Retrieve image from microsoft
#FROM which docker image we are using. It means .net core docker image as a base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#1. Build app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#Create folder in image
WORKDIR /src
#Copy local to image
COPY src/CatalogAPI/CatalogAPI.csproj src/CatalogAPI/
RUN dotnet restore "src/CatalogAPI/CatalogAPI.csproj"
COPY . .
#Set the working directory
WORKDIR "/src/src/CatalogAPI"
#.Net build command
RUN dotnet build "CatalogAPI.csproj" -c Release -o /app/build

#2. Publish & run
FROM build AS publish
RUN dotnet publish "CatalogAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogAPI.dll"]
