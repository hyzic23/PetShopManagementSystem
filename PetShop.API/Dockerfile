FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 8000

ENV ASPNETCORE_URLS=http://+:8000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["PetShop.API/PetShop.API.csproj", "PetShop.API/"]
COPY ["PetShop.Core/PetShop.Core.csproj", "PetShop.Core/"]
COPY ["PetShop.Infrastructure/PetShop.Infrastructure.csproj", "PetShop.Infrastructure/"]
RUN dotnet restore "PetShop.API/PetShop.API.csproj"
COPY . .
WORKDIR "/src/PetShop.API"
RUN dotnet build "PetShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetShop.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetShop.API.dll"]
