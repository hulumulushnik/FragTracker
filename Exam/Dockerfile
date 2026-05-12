# 1. Етап збірки (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо файл проекту (використовуємо реальну назву Exam.csproj)
COPY ["Exam.csproj", "./"]
RUN dotnet restore "Exam.csproj"

# Копіюємо всі інші файли (включаючи папку Migrations)
COPY . .
RUN dotnet build "Exam.csproj" -c Release -o /app/build

# 2. Етап публікації (Publish)
FROM build AS publish
RUN dotnet publish "Exam.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 3. Фінальний образ для запуску (Final)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

# Відкриваємо порт 80 для HTTP трафіку
EXPOSE 80
# ВАЖЛИВО: Назва DLL має відповідати назві проекту, тобто Exam.dll
ENTRYPOINT ["dotnet", "Exam.dll"]