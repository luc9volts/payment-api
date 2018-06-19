# Moip Technical Challenge

## How to run:
- Install .NET Core 2.1 SDK
- In the **tests/UnitTests** folder run: **dotnet test**
- In the **src/Web** folder run: **dotnet run**
- Checkout page: ~/checkout/index.html
- _Database is embedded_

## Docker Hub:
- docker pull luc9volts/paymentapi
- docker run -p 8080:80 luc9volts/paymentapi

## Design:
- Layered Architecture
- Abstract Factory Pattern
- Repository Pattern
- Dependency inversion principle
