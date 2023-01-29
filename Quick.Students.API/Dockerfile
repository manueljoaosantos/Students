FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5275

ENV ASPNETCORE_URLS=http://+:5275

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Quick.Students.API/Quick.Students.API.csproj", "Quick.Students.API/"]
RUN dotnet restore "Quick.Students.API/Quick.Students.API.csproj"
COPY . .
WORKDIR "/src/Quick.Students.API"
RUN dotnet build "Quick.Students.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quick.Students.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quick.Students.API.dll"]
