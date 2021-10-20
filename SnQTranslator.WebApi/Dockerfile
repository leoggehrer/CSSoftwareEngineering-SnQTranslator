#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SnQTranslator.WebApi/SnQTranslator.WebApi.csproj", "SnQTranslator.WebApi/"]
COPY ["SnQTranslator.Transfer/SnQTranslator.Transfer.csproj", "SnQTranslator.Transfer/"]
COPY ["SnQTranslator.Contracts/SnQTranslator.Contracts.csproj", "SnQTranslator.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["SnQTranslator.Logic/SnQTranslator.Logic.csproj", "SnQTranslator.Logic/"]
RUN dotnet restore "SnQTranslator.WebApi/SnQTranslator.WebApi.csproj"
COPY . .
WORKDIR "/src/SnQTranslator.WebApi"
RUN dotnet build "SnQTranslator.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnQTranslator.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnQTranslator.WebApi.dll"]