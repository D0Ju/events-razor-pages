# Aplikacija za Upravljanje Događajima - ASP.NET Core Razor Pages

## Pregled Projekta

Ovo je web aplikacija za upravljanje događajima izgrađena sa **ASP.NET Core Razor Pages**, **Entity Framework Core**, i **Bootstrap** tematskim sustavom.

---

## Modeli Podataka

### 1. **Događaj (Event)**

- **Id** (int) - Primarni ključ
- **Naziv** (string) - Naziv događaja
- **Lokacija** (string) - Mjesto održavanja
- **DatumPocetka** (DateTime) - Početak događaja
- **DatumZavrsetka** (DateTime) - Kraj događaja
- **BrojPolaznika** (int) - Broj polaznika
- **Cijena** (decimal) - Cijena karte/prijavnice
- **Opis** (string) - Detaljni opis
- **Aktivan** (bool) - Status aktivnosti
- **VrstaId** (int) - Strani ključ na VrstaDogađaja

### 2. **Vrsta Događaja (EventType)**

- **Id** (int) - Primarni ključ
- **Naziv** (string) - Naziv vrste
- **Opis** (string) - Opis vrste
- **MinimalnoPolaznika** (int) - Minimalan broj polaznika

---

## Stranice Aplikacije

### Početna Stranica

- **Index.cshtml** - Lepa početna stranica sa hero sekcijom i značajkama

### Upravljanje Događajima

- **Event/Index.cshtml** - Pregled svih događaja u tabelarnom obliku
- **Event/Create.cshtml** - Forma za kreiranje novog događaja
- **Event/Edit.cshtml** - Forma za uređivanje postojećeg događaja
- **Event/Delete.cshtml** - Potvrda za brisanje događaja
- **Event/Details.cshtml** - Detaljni pregled pojedinog događaja
- **Event/FilterByType.cshtml** - Filtriranje događaja po vrsti
- **Event/SortedByDate.cshtml** - Sortiranje događaja po datumu

### Upravljanje Vrstama Događaja

- **EventType/Index.cshtml** - Pregled svih vrsta događaja
- **EventType/Create.cshtml** - Kreiranje nove vrste
- **EventType/Edit.cshtml** - Uređivanje vrste
- **EventType/Delete.cshtml** - Brisanje vrste
- **EventType/Details.cshtml** - Detalji vrste

---

## Partial Views (Komponente)

### \_Layout.cshtml

- Master layout za sve stranice
- Navigacijska traka sa modemom responsivnosti
- Footer sa informacijama
- Uključuje Bootstrap i custom CSS/JS

### \_Navigation.cshtml

- Reusable navigacijska komponenta
- Dark Bootstrap tema
- Dropdown meni za vrste događaja
- Responsive dizajn

### \_DogađajCard.cshtml

- Komponenta za prikaz pojedinačnog događaja
- Bootstrap card sa gradijent headerom
- Akcijske dugmadi (Detalji, Uredi, Obriši)
- Prikazuje sve relevantne informacije

---

## Tehnologije i Biblioteke

### Backend

- **ASP.NET Core** - Web framework
- **Entity Framework Core** - ORM za bazu podataka
- **SQL Server / SQLite** - Baza podataka

### Frontend

- **Bootstrap 5** - CSS framework
- **Bootstrap Icons** - Ikone
- **Custom CSS** - events-theme.css za dodatni stil
- **JavaScript** - events.js za interakcije

---

## Styling i Dizajn

### events-theme.css

Uključuje:

- Custom CSS varijable za boje
- Hero sekcija sa gradijentom
- Feature cards sa hover efektima
- Event cards sa animacijama
- Stilizovane tablice
- Responsive dizajn
- Bootstrap integracija

### Boje Teme

- **Primarni**: #0d6efd (plava)
- **Sekundarni**: #6c757d (siva)
- **Uspjeh**: #198754 (zelena)
- **Opasnost**: #dc3545 (crvena)
- **Upozorenje**: #ffc107 (žuta)

---

## JavaScript Funkcionalnosti (events.js)

### Bootstrap Komponente

- Tooltips i Popovers inicijalizacija
- Form validacija

### Helper Funkcije

- `formatDate()` - Formatiranje datuma
- `formatCurrency()` - Formatiranje cijene
- `showNotification()` - Prikazivanje obavijesti

### Event Listeners

- Potvrda prije brisanja
- Form validacija

---

## Lokalizacija

**Hrvatski jezk (hr-HR):**

- Sve stranice i komponente su na hrvatskom
- Datumi su formatirani kao DD.MM.YYYY
- Cijene su prikazane kao HRK (Hrvatska kuna)
- Sve poruke i labele su na hrvatskom

---

## Baza Podataka

### Entity Framework Core Migracije

```bash
# Kreiranje migracije
dotnet ef migrations add InitialCreate

# Ažuriranje baze
dotnet ef database update
```

### Veza između Modela

- Jedan **EventType** može imati više **Event** zapisa
- Svaki **Event** mora biti povezan sa **EventType** (FK)

---

## Kako Pokrenuti Aplikaciju

1. **Kloniraj projekt**

   ```bash
   git clone <repo-url>
   cd events-razor-pages
   ```

2. **Instaliraj dependencije**

   ```bash
   dotnet restore
   ```

3. **Kreiraj i ažuriraj bazu**

   ```bash
   dotnet ef database update
   ```

4. **Pokreni aplikaciju**

   ```bash
   dotnet run
   ```

5. **Otvori u pregledniku**
   ```
   https://localhost:7000
   ```

---

## Struktura Projekta

```
├── Models/
│   ├── Event.cs
│   └── EventType.cs
├── Data/
│   └── EventDbContext.cs
├── Migrations/
│   └── [EF Core migrations]
├── Pages/
│   ├── Index.cshtml
│   ├── Event/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── FilterByType.cshtml
│   │   └── SortedByDate.cshtml
│   ├── EventType/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   └── Details.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Navigation.cshtml
│       └── _DogađajCard.cshtml
├── wwwroot/
│   ├── css/
│   │   ├── site.css
│   │   └── events-theme.css
│   └── js/
│       ├── site.js
│       └── events.js
└── events-razor-pages.csproj
```

---

## Zahtjevi Projekta - Checklist

✅ **Modeli** - Minimalno 5 svojstava i 4 različita tipa podataka  
✅ **Veza između modela** - Event -> EventType (FK)  
✅ **Razor Pages** - Sve potrebne stranice kreirane  
✅ **Bootstrap tema** - Profesionalna event tema  
✅ **Custom CSS** - events-theme.css sa advanced stilizacijom  
✅ **Custom JS** - events.js sa funkcionalnostima  
✅ **Partial Views** - \_Navigation.cshtml i \_DogađajCard.cshtml  
✅ **Entity Framework Core** - Koristi se za podatke  
✅ **Layout** - Master layout sa 2 partiala  
✅ **Lokalizacija** - Hrvatski jezik (hr-HR)  
✅ **Filtriranje** - Event/FilterByType.cshtml  
✅ **Sortiranje** - Event/SortedByDate.cshtml

---

## Autor

Izgrađeno kao dio ASP.NET Core Razor Pages projekta.

**Datum**: Siječanj 2026
