#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PathCase.API/PathCase.API.csproj", "PathCase.API/"]
COPY ["PathCase.DataLayer/PathCase.DataLayer.csproj", "PathCase.DataLayer/"]
COPY ["PathCase.Entities/PathCase.Entities.csproj", "PathCase.Entities/"]
COPY ["PathCase.BusinessLayer/PathCase.BusinessLayer.csproj", "PathCase.BusinessLayer/"]
RUN dotnet restore "PathCase.API/PathCase.API.csproj"
COPY . .
WORKDIR "/src/PathCase.API"
RUN dotnet build "PathCase.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PathCase.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PathCase.API.dll"]