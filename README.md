# InsurePartner - Upravljanje Partnerima i Policama Osiguranja

InsurePartner je web aplikacija razvijena u **ASP.NET Core Razor Pages** tehnologiji koja omogućuje evidenciju partnera (osoba i pravnih osoba) te brzi unos i pregled njihovih polica osiguranja. 

Aplikacija koristi **Dapper ORM** za brzu i efikasnu komunikaciju s SQL Server bazom podataka.

---

## 🚀 Ključne Funkcionalnosti

* **Pregled partnera:** Tablični prikaz svih partnera povučenih iz baze uz izračun ukupnog broja polica i ukupnog iznosa.
* **Vizualni indikatori (Zvijezdica):** Partneri koji imaju više od 5 polica ili ukupan iznos veći od 5.000 € automatski dobivaju oznaku `*` pokraj imena.
* **Unos novog partnera:** Zasebna stranica s formom i validacijom (OIB, tip partnera, spol...).
* **Brzi unos police (Bootstrap Modal):** Klikom na bilo kojeg partnera u tablici automatski se otvara skočni prozor (modal) s predodređenom vanjskom šifrom partnera za brzi unos nove police.

---

## Slike i Vizualni Prikazi

### Lista Partnera

![Lista Partnera](InsurePartner/Slike/Lista%20Partnera.png)

### Unos Novog Partnera

![Unos Novog Partnera](InsurePartner/Slike/Unos%20Novog%20Partnera.png)

### Unos Police

![Unos Police](InsurePartner/Slike/Unos%20Nove%20Police%20Osiguranja.png)

---

## 🛠️ Tehnološki Stog (Tech Stack)

* **Backend:** .NET 8 / ASP.NET Core Razor Pages
* **Pristup bazi podataka:** Dapper (Micro-ORM) & Microsoft.Data.SqlClient
* **Baza podataka:** Microsoft SQL Server
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript (Vanilla)

---

## 📋 Postupak Pokretanja i Konfiguracija

Kako biste pokrenuli aplikaciju lokalno na računalu, pratite sljedeće korake:

### 1. Preduvjeti
Provjerite imate li instalirano:
* Visual Studio 2022 (s obuhvaćenim .NET Web Development paketom)
* SQL Server Management Studio (Lokalna instanca ili LocalDB)

### 2. Konfiguracija baze podataka (Connection String)
U datoteci `appsettings.json` prilagodite *Connection String* kako bi pokazivao na Vašu lokalnu bazu podataka:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InsurePartner_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
