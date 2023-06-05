#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bookly.API/Bookly.API.csproj", "Bookly.API/"]
COPY ["Bookly.Domain/Bookly.Domain.csproj", "Bookly.Domain/"]
COPY ["Bookly.Infrastructure.Email/Bookly.Infrastructure.Email.csproj", "Bookly.Infrastructure.Email/"]
COPY ["Bookly.Infrastructure.Identity/Bookly.Infrastructure.Identity.csproj", "Bookly.Infrastructure.Identity/"]
COPY ["Bookly.Infrastructure.Persistence/Bookly.Infrastructure.Persistence.csproj", "Bookly.Infrastructure.Persistence/"]
RUN dotnet restore "Bookly.API/Bookly.API.csproj"
COPY . .
WORKDIR "/src/Bookly.API"
RUN dotnet build "Bookly.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookly.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookly.API.dll"]