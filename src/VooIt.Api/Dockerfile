FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/VooIt.Api/VooIt.Api.csproj", "src/VooIt.Api/"]
COPY ["src/VooIT.Common/VooIT.Common.csproj", "src/VooIT.Common/"]
COPY ["src/VooIt.Domain/VooIt.Domain.csproj", "src/VooIt.Domain/"]
RUN dotnet restore "src/VooIt.Api/VooIt.Api.csproj"
COPY . .
WORKDIR "/src/src/VooIt.Api"
RUN dotnet build "VooIt.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VooIt.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VooIt.Api.dll"]