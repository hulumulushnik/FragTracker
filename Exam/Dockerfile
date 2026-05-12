# 1. Етап збірки (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо файл проекту та відновлюємо залежності
COPY ["FragTracker.csproj", "./"]
RUN dotnet restore "FragTracker.csproj"

# Копіюємо всі інші файли (включаючи вашу папку Migrations!)
COPY . .
RUN dotnet build "FragTracker.csproj" -c Release -o /app/build

# 2. Етап публікації (Publish)
FROM build AS publish
RUN dotnet publish "FragTracker.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 3. Фінальний образ для запуску (Final)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

# Відкриваємо порт для сайту
EXPOSE 80
ENTRYPOINT ["dotnet", "FragTracker.dll"]