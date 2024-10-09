using ExemploLinq;
using ExemploLinq.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

if (!context.Lojas.Any())
{
    DatabaseSeeder.SeedData(context);
}

ExibirLojasECarros(context);

Console.WriteLine("-----------------------------------------");
Console.WriteLine("Executando suas consultas");

Exercicio.ExecutarConsultas();

static void ExibirLojasECarros(AppDbContext context)
{
    var lojas = context.Lojas
        .Include(l => l.Carros)
        .ThenInclude(c => c.Marca)
        .ToList();

    foreach (var loja in lojas)
    {
        Console.WriteLine($"Loja: {loja.Nome}");
        foreach (var carro in loja.Carros)
        {
            Console.WriteLine($"\tCarro: {carro.Modelo} - Ano: {carro.Ano} - Marca: {carro.Marca.Nome}");
        }
    }
}

