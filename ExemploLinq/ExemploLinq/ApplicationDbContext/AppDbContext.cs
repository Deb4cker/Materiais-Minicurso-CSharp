using ExemploLinq.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace ExemploLinq.ApplicationDbContext;

public class AppDbContext : DbContext
{
    public DbSet<Loja> Lojas { get; set; }
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Marca> Marcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=carros.db")
            .LogTo(FormatSql, LogLevel.Information);
    }

    private void FormatSql(string sql)
    { 
        var match = _logRegex.Match(sql);
        if (match.Success)
        {
            var query = match.Groups[1].Value.Trim();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+--------------------------------Query--------------------------------+");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(query);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.ResetColor();
        }
    }

    private readonly Regex _logRegex = new(@"Executed DbCommand.*?(\s*.*?)(?:RETURNING|;|$)", RegexOptions.Singleline);
}
