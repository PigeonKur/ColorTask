# ColorLibrary
---
**ColorLibrary** — библиотека для работы с цветовыми моделями RGB, HEX и HSL. Разработана в рамках учебного проекта по программированию и предназначена для демонстрации преобразований между цветами в различных форматах.

## Предметная область

Методы для преобразования между различными цветовыми моделями (RGB, HEX, HSL) и манипуляции с цветами

## Возможности

- RGB → HEX
- HEX → RGB
- RGB → HSL

## Установка
```
git clone https://github.com/your-username/ColorLibrary.git
dotnet build
```
## Использование
```
csharp
ColorConverter.RgbToHex(255, 100, 50);         // "#FF6432"
ColorConverter.HexToRgb("#FF6432");            // (255, 100, 50)
ColorConverter.RgbToHsl(255, 100, 50);          // (17.65, 100.00, 59.80)
```
## Тестирование
```
dotnet test
```
## CI/CD

Сборка и тесты автоматизированы с помощью **GitHub Actions**.
