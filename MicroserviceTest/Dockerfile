FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroserviceTest/MicroserviceTest.csproj", "MicroserviceTest/"]
RUN dotnet restore "MicroserviceTest/MicroserviceTest.csproj"
COPY . .
WORKDIR "/src/MicroserviceTest"
RUN dotnet build "MicroserviceTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroserviceTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroserviceTest.dll"]
