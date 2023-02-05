#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["KBC_demoCore/KBC_demoCore.csproj", "KBC_demoCore/"]
RUN dotnet restore "KBC_demoCore/KBC_demoCore.csproj"
COPY . .
WORKDIR "/src/KBC_demoCore"
RUN dotnet build "KBC_demoCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KBC_demoCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KBC_demoCore.dll"]
