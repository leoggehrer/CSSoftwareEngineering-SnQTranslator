#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CSharpCodeGenerator.Logic/CSharpCodeGenerator.Logic.csproj", "CSharpCodeGenerator.Logic/"]
COPY ["CSharpCodeGenerator.ConApp/CSharpCodeGenerator.ConApp.csproj", "CSharpCodeGenerator.ConApp/"]
COPY ["SnQTranslator.AspMvc/SnQTranslator.AspMvc.csproj", "SnQTranslator.AspMvc/"]
COPY ["SnQTranslator.Adapters/SnQTranslator.Adapters.csproj", "SnQTranslator.Adapters/"]
COPY ["SnQTranslator.Transfer/SnQTranslator.Transfer.csproj", "SnQTranslator.Transfer/"]
COPY ["SnQTranslator.Contracts/SnQTranslator.Contracts.csproj", "SnQTranslator.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["SnQTranslator.Logic/SnQTranslator.Logic.csproj", "SnQTranslator.Logic/"]
RUN dotnet restore "SnQTranslator.AspMvc/SnQTranslator.AspMvc.csproj"
COPY . .

WORKDIR "/src/CSharpCodeGenerator.ConApp"
RUN dotnet build "CSharpCodeGenerator.ConApp.csproj" -c Release -o /app/build

WORKDIR "/src/SnQTranslator.Contracts"
RUN dotnet build "SnQTranslator.Contracts.csproj" -c Release -o /app/build

WORKDIR "/src/SnQTranslator.AspMvc"
RUN dotnet build "SnQTranslator.AspMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnQTranslator.AspMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnQTranslator.AspMvc.dll"]