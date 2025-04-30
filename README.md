
# 🏦 BankApp – Ett enkelt banksystem med Blazor och Web API

## 📋 Beskrivning

Detta projekt är en demo av ett enkelt banksystem där användare kan:

- Skapa konton
- Göra insättningar och uttag
- Utföra överföringar mellan konton
- Visa transaktionshistorik

Applikationen är uppdelad i två delar:
- **BankApp.API** – backend med ASP.NET Core Web API och Entity Framework Core
- **BankApp.Client** – frontend i Blazor WebAssembly

## 🧱 Tekniker som används

- ASP.NET Core 7
- Entity Framework Core
- Blazor WebAssembly
- SQL Server (LocalDB)
- REST API (JSON)

## 🚀 Funktioner

- Kontooperationer (insättning, uttag, saldo)
- Överföring mellan konton
- Transaktionshistorik per konto
- API med full CRUD
- Modern frontend i Blazor

## 📂 Struktur

```
BankApp/
├── BankApp.API/         // Web API-projekt (Controllers, Models, Context)
├── BankApp.Client/      // Blazor WebAssembly-projekt (Pages, Services)
├── README.md            // Den här filen
```

## 🛠️ Kör lokalt

1. Klona detta repo:
```bash
git clone https://github.com/ditt-användarnamn/bankapp.git
```

2. Kör `dotnet ef database update` för att skapa databasen  
   *(eller använd `EnsureCreated()` i Program.cs)*

3. Starta både `BankApp.API` och `BankApp.Client` i Visual Studio

## 👤 Författare

Detta projekt är skapat som en del av en inlämningsuppgift för KYH-kursen **"Nätverksteknik – Industriell och IT-säkerhet"**.
