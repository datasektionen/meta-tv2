FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Meta-TV2-AccessLayer/*.csproj ./Meta-TV2-AccessLayer/
COPY Meta-TV2-BusinessLayer/*.csproj ./Meta-TV2-BusinessLayer/
COPY Meta-TV2-DataLayer/*.csproj ./Meta-TV2-DataLayer/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/Meta-TV2-AccessLayer
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
ENV ASPNETCORE_URLS http://*:5000
WORKDIR /app
COPY --from=build /app/Meta-TV2-AccessLayer/out ./
CMD ["dotnet", "Meta-TV2-api.dll"]
