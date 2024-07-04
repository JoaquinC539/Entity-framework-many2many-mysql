FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

RUN apt-get update && apt-get install -y libxml2

WORKDIR /APP

COPY . ./

RUN dotnet restore

RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /APP
COPY --from=build-env /APP/out .
EXPOSE 8080
ENTRYPOINT [ "dotnet","PizzaApp.dll" ]