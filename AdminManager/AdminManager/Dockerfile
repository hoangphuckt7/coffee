#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdminManager/AdminManager.csproj", "AdminManager/"]
RUN dotnet restore "AdminManager/AdminManager.csproj"
COPY . .
WORKDIR "/src/AdminManager"
RUN dotnet build "AdminManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminManager.dll"]