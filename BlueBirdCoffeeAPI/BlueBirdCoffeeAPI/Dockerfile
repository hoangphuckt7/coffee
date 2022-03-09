#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlueBirdCoffeeAPI/BlueBirdCoffeeAPI.csproj", "BlueBirdCoffeeAPI/"]
RUN dotnet restore "BlueBirdCoffeeAPI/BlueBirdCoffeeAPI.csproj"
COPY . .
WORKDIR "/src/BlueBirdCoffeeAPI"
RUN dotnet build "BlueBirdCoffeeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueBirdCoffeeAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueBirdCoffeeAPI.dll"]