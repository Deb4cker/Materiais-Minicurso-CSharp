namespace ExemploLinq.Model;

public class Marca
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Carro> Carros { get; set; } = [];
}
