namespace ExemploLinq.Model;

public class Carro
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public Marca Marca { get; set; }
    public Loja Loja { get; set; }
}
