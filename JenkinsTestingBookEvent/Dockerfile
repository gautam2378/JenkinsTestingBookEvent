#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bookeventapplication/Bookeventapplication.csproj", "Bookeventapplication/"]
RUN dotnet restore "Bookeventapplication/Bookeventapplication.csproj"
COPY . .
WORKDIR "/src/Bookeventapplication"
RUN dotnet build "Bookeventapplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookeventapplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookeventapplication.dll"]