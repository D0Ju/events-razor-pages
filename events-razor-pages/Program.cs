using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventsRazorApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventDbContext") ?? throw new InvalidOperationException("Connection string 'EventDbContext' not found.")));

var app = builder.Build();

// Seed database with initial EventTypes
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EventDbContext>();
    
    // Check if EventTypes already exist
    if (!db.EventType.Any())
    {
        var eventTypes = new List<EventType>
        {
            new EventType { Naziv = "Koncert", Opis = "Glazbeni koncert raznih žanrova", MinimalnoPolaznika = 10 },
            new EventType { Naziv = "Konferencija", Opis = "Poslovne i stručne konferencije", MinimalnoPolaznika = 20 },
            new EventType { Naziv = "Filmska projekcija", Opis = "Kinematografski proizvodi i projekcije", MinimalnoPolaznika = 5 },
            new EventType { Naziv = "Teatar", Opis = "Kazališne predstave i драме", MinimalnoPolaznika = 15 },
            new EventType { Naziv = "Sportski događaj", Opis = "Sportske utakmice i natjecanja", MinimalnoPolaznika = 25 },
            new EventType { Naziv = "Radionice", Opis = "Edukativne radionice i trenazi", MinimalnoPolaznika = 8 },
            new EventType { Naziv = "Festival", Opis = "Večednevni festivali i svečanosti", MinimalnoPolaznika = 50 },
            new EventType { Naziv = "Izložba", Opis = "Художничке i znanstvene izložbe", MinimalnoPolaznika = 5 }
        };

        db.EventType.AddRange(eventTypes);
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
