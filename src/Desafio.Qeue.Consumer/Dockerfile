#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Desafio.Qeue.Consumer/Desafio.Qeue.Consumer.csproj", "src/Desafio.Qeue.Consumer/"]
COPY ["src/Desafio.Domain/Desafio.Domain.csproj", "src/Desafio.Domain/"]
RUN dotnet restore "src/Desafio.Qeue.Consumer/Desafio.Qeue.Consumer.csproj"
COPY . .
WORKDIR "/src/src/Desafio.Qeue.Consumer"
RUN dotnet build "Desafio.Qeue.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio.Qeue.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Qeue.Consumer.dll"]
