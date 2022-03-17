#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["drm_NotePad.csproj", "."]
RUN dotnet restore "./drm_NotePad.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "drm_NotePad.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "drm_NotePad.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "drm_NotePad.dll"]