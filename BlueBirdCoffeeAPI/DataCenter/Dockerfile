#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataCenter/DataCenter.csproj", "DataCenter/"]
RUN dotnet restore "DataCenter/DataCenter.csproj"
COPY . .
WORKDIR "/src/DataCenter"
RUN dotnet build "DataCenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataCenter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataCenter.dll"]