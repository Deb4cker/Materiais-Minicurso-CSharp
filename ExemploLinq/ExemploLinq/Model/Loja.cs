namespace ExemploLinq.Model;

public class Loja
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Carro> Carros { get; set; } = [];
}
