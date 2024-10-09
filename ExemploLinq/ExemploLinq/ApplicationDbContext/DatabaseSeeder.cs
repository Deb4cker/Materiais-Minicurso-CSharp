using ExemploLinq.Model;

namespace ExemploLinq.ApplicationDbContext;

public class DatabaseSeeder
{
    public static void SeedData(AppDbContext context)
    { 
        var brands = new List<Marca>
        {
            new() { Nome = "Fiat" },
            new() { Nome = "Ford" },
            new() { Nome = "Jeep" },
            new() { Nome = "Honda" },
            new() { Nome = "Nissan" },
            new() { Nome = "Toyota" },
            new() { Nome = "Hyundai" },
            new() { Nome = "Renault" },
            new() { Nome = "Chevrolet" },
            new() { Nome = "Volkswagen" },
        };
        context.Marcas.AddRange(brands);
        context.SaveChanges();

        var stores = new List<Loja>
        {
            new() { Nome = "Loja Sul" },
            new() { Nome = "Loja Norte" },
            new() { Nome = "Loja Leste" },
            new() { Nome = "Loja Oeste" },
            new() { Nome = "Loja Centro" },
        };
        context.Lojas.AddRange(stores);
        context.SaveChanges();

        var cars = new List<Carro>
        {
            new() { Modelo = "Ka", Ano = 2018, Marca = brands.First(m => m.Nome == "Ford"), Loja = stores[4] },
            new() { Modelo = "Fit", Ano = 2020, Marca = brands.First(m => m.Nome == "Honda"), Loja = stores[0] },
            new() { Modelo = "Argo", Ano = 2019, Marca = brands.First(m => m.Nome == "Fiat"), Loja = stores[3] },
            new() { Modelo = "Civic", Ano = 2019, Marca = brands.First(m => m.Nome == "Honda"), Loja = stores[0] },
            new() { Modelo = "Cronos", Ano = 2020, Marca = brands.First(m => m.Nome == "Fiat"), Loja = stores[3] },
            new() { Modelo = "Kicks", Ano = 2020, Marca = brands.First(m => m.Nome == "Nissan"), Loja = stores[1] },
            new() { Modelo = "Versa", Ano = 2019, Marca = brands.First(m => m.Nome == "Nissan"), Loja = stores[1] },
            new() { Modelo = "HB20", Ano = 2019, Marca = brands.First(m => m.Nome == "Hyundai"), Loja = stores[2] },
            new() { Modelo = "Hilux", Ano = 2021, Marca = brands.First(m => m.Nome == "Toyota"), Loja = stores[4] },
            new() { Modelo = "Compass", Ano = 2021, Marca = brands.First(m => m.Nome == "Jeep"), Loja = stores[3] },
            new() { Modelo = "Renegade", Ano = 2020, Marca = brands.First(m => m.Nome == "Jeep"), Loja = stores[2] },
            new() { Modelo = "Creta", Ano = 2021, Marca = brands.First(m => m.Nome == "Hyundai"), Loja = stores[3] },
            new() { Modelo = "EcoSport", Ano = 2020, Marca = brands.First(m => m.Nome == "Ford"), Loja = stores[4] },
            new() { Modelo = "Onix", Ano = 2018, Marca = brands.First(m => m.Nome == "Chevrolet"), Loja = stores[0] },
            new() { Modelo = "Gol", Ano = 2017, Marca = brands.First(m => m.Nome == "Volkswagen"), Loja = stores[1] },
            new() { Modelo = "Duster", Ano = 2021, Marca = brands.First(m => m.Nome == "Renault"), Loja = stores[1] },
            new() { Modelo = "Corolla", Ano = 2020, Marca = brands.First(m => m.Nome == "Toyota"), Loja = stores[4] },
            new() { Modelo = "Sandero", Ano = 2019, Marca = brands.First(m => m.Nome == "Renault"), Loja = stores[0] },
            new() { Modelo = "Polo", Ano = 2020, Marca = brands.First(m => m.Nome == "Volkswagen"), Loja = stores[2] },
            new() { Modelo = "Prisma", Ano = 2019, Marca = brands.First(m => m.Nome == "Chevrolet"), Loja = stores[0] },
            new() { Modelo = "Tracker", Ano = 2020, Marca = brands.First(m => m.Nome == "Chevrolet"), Loja = stores[1] },
            new() { Modelo = "Virtus", Ano = 2021, Marca = brands.First(m => m.Nome == "Volkswagen"), Loja = stores[2] },
        };
        context.Carros.AddRange(cars);
        
        context.SaveChanges();
    }
}
