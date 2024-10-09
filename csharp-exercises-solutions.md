# Gabarito Completo - Exercícios C#

## Exercício 1

```csharp
Console.Write("Por favor, digite seu nome: ");
var nome = Console.ReadLine();
var agora = DateTime.Now;
Console.WriteLine($"Hello, {nome}! Agora são {agora:HH:mm} do dia {agora:dd/MM/yyyy}.");
```

## Exercício 2

```csharp
var continuar = true;

while (continuar)
{
    var numero1 = LerNumero("Digite o primeiro número: ");
    var numero2 = LerNumero("Digite o segundo número: ");

    Console.Write("Escolha a operação (+, -, *, /): ");
    var operacao = Console.ReadLine();

    var resultado = operacao switch
    {
        "+" => numero1 + numero2,
        "-" => numero1 - numero2,
        "*" => numero1 * numero2,
        "/" when numero2 != 0 => numero1 / numero2,
        "/" => double.NaN,
        _ => double.NaN
    };

    if (double.IsNaN(resultado))
    {
        if (operacao == "/")
            Console.WriteLine("Erro: Divisão por zero não é permitida.");
        else
            Console.WriteLine("Operação inválida.");
    }
    else
    {
        Console.WriteLine($"Resultado: {resultado}");
    }

    Console.Write("Deseja fazer outro cálculo? (s/n): ");
    continuar = Console.ReadLine().Trim().ToLower() == "s";
}

static double LerNumero(string mensagem)
{
    double numero;
    while (true)
    {
        Console.Write(mensagem);
        if (double.TryParse(Console.ReadLine(), out numero))
            return numero;

        Console.WriteLine("Valor inválido. Tente novamente.");
    }
}
```

## Exercício 3

```csharp
var continuar = true;

double ConverterCelsiusParaFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
double ConverterFahrenheitParaCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

while (continuar)
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1. Converter de Celsius para Fahrenheit");
    Console.WriteLine("2. Converter de Fahrenheit para Celsius");
    Console.WriteLine("3. Sair");
    
    var opcao = Console.ReadLine();
    
    if (opcao == "3")
    {
        continuar = false;
        Console.WriteLine("Saindo...");
        break;
    }

    Console.Write("Digite a temperatura: ");
    
    if (!double.TryParse(Console.ReadLine(), out var temperatura))
    {
        Console.WriteLine("Valor inválido.");
        continue;
    }

    var resultado = opcao switch
    {
        "1" => ConverterCelsiusParaFahrenheit(temperatura),
        "2" => ConverterFahrenheitParaCelsius(temperatura),
        _ => double.NaN
    };

    if (double.IsNaN(resultado))
    {
        Console.WriteLine("Opção inválida.");
    }
    else
    {
        var unidade = opcao == "1" ? "°F" : "°C";
        Console.WriteLine($"Temperatura convertida: {resultado:F2}{unidade}");
    }

    Console.WriteLine();
}

```

## Exercício 4

```csharp
var continuar = true;

while (continuar)
{
    Console.Write("Digite um número inteiro entre 1 e 20: ");
    
    if (int.TryParse(Console.ReadLine(), out int numero) && numero is >= 1 and <= 20)
    {
        Console.WriteLine($"Tabuada do {numero}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero,2} x {i,2} = {numero * i,3}");
        }
    }
    else
    {
        Console.WriteLine("Número inválido. Digite um valor entre 1 e 20.");
    }

    Console.Write("Deseja calcular outra tabuada? (s/n): ");
    continuar = Console.ReadLine()?.Trim().ToLower() == "s";
}
```

## Exercício 5

```csharp
const int numeroAlunos = 5;
const int numeroNotas = 4;
string[] alunos = new string[numeroAlunos];
double[,] notas = new double[numeroAlunos, numeroNotas];
double[] medias = new double[numeroAlunos];
double somaTurma = 0;

for (int i = 0; i < numeroAlunos; i++)
{
    Console.Write($"Digite o nome do aluno {i + 1}: ");
    alunos[i] = Console.ReadLine() ?? "";

    double somaNotas = 0;
    for (int j = 0; j < numeroNotas; j++)
    {
        Console.Write($"Digite a nota {j + 1} do aluno {alunos[i]}: ");

        while (!double.TryParse(Console.ReadLine(), out double nota))
        {
            Console.WriteLine("Valor inválido, digite um número válido.");
            Console.Write($"Digite a nota {j + 1} do aluno {alunos[i]}: ");
        }
        notas[i, j] = nota;
        somaNotas += notas[i, j];
    }

    medias[i] = somaNotas / numeroNotas;
    somaTurma += medias[i];
}

Console.WriteLine("\nRelatório de Alunos:");
Console.WriteLine($"{"Aluno",-15}{"Média",-10}{"Situação",-15}");
for (int i = 0; i < numeroAlunos; i++)
{
    string situacao = medias[i] switch
    {
        >= 7 => "Aprovado",
        >= 5 => "Recuperação",
        _ => "Reprovado"
    };

    Console.WriteLine($"{alunos[i],-15}{medias[i],-10:F2}{situacao,-15}");
}

double mediaGeral = somaTurma / numeroAlunos;
Console.WriteLine($"\nMédia geral da turma: {mediaGeral:F2}");
```

## Exercício 6

```csharp
Random random = new Random();
int[] numeros = new int[15];

// Preenche o array com números aleatórios
for (int i = 0; i < numeros.Length; i++)
{
    numeros[i] = random.Next(1, 101);
}

// Exibe o array ordenado
Array.Sort(numeros);
Console.WriteLine("Array ordenado: " + string.Join(", ", numeros));

bool continuar = true;
while (continuar)
{
    // Menu de opções
    Console.WriteLine("\nEscolha uma busca:");
    Console.WriteLine("1. Buscar por valor exato");
    Console.WriteLine("2. Buscar por valor maior que");
    Console.WriteLine("3. Buscar por valor menor que");
    Console.WriteLine("4. Sair");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Digite o valor exato: ");
            if (int.TryParse(Console.ReadLine(), out int valorExato))
            {
                BuscarValor(numeros, valorExato, "exato");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            break;
        case "2":
            Console.Write("Digite o valor maior que: ");
            if (int.TryParse(Console.ReadLine(), out int valorMaior))
            {
                BuscarValor(numeros, valorMaior, "maior");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            break;
        case "3":
            Console.Write("Digite o valor menor que: ");
            if (int.TryParse(Console.ReadLine(), out int valorMenor))
            {
                BuscarValor(numeros, valorMenor, "menor");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            break;
        case "4":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

static void BuscarValor(int[] array, int valor, string criterio)
{
    bool encontrado = false;

    for (int i = 0; i < array.Length; i++)
    {
        bool condicao = criterio switch
        {
            "exato" => array[i] == valor,
            "maior" => array[i] > valor,
            "menor" => array[i] < valor,
            _ => false
        };

        if (condicao)
        {
            encontrado = true;
            Console.WriteLine($"Valor {array[i]} encontrado na posição {i}");
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("Nenhuma ocorrência encontrada.");
    }
}
```

## Exercício 7

```csharp
int[,] matriz = new int[3, 3];

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"Digite o valor para a posição [{i},{j}]: ");
        matriz[i, j] = int.Parse(Console.ReadLine());
    }
}

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\nEscolha uma operação:");
    Console.WriteLine("1. Mostrar a matriz original");
    Console.WriteLine("2. Mostrar a matriz transposta");
    Console.WriteLine("3. Somar todos os elementos");
    Console.WriteLine("4. Mostrar a soma de cada linha");
    Console.WriteLine("5. Mostrar a soma de cada coluna");
    Console.WriteLine("6. Mostrar a diagonal principal");
    Console.WriteLine("7. Sair");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            MostrarMatriz(matriz);
            break;
        case "2":
            MostrarTransposta(matriz);
            break;
        case "3":
            SomarElementos(matriz);
            break;
        case "4":
            SomarLinhas(matriz);
            break;
        case "5":
            SomarColunas(matriz);
            break;
        case "6":
            MostrarDiagonalPrincipal(matriz);
            break;
        case "7":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

static void MostrarMatriz(int[,] matriz)
{
    Console.WriteLine("Matriz Original:");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{matriz[i, j],3} ");
        }
        Console.WriteLine();
    }
}

static void MostrarTransposta(int[,] matriz)
{
    Console.WriteLine("Matriz Transposta:");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{matriz[j, i],3} ");
        }
        Console.WriteLine();
    }
}

static void SomarElementos(int[,] matriz)
{
    int soma = 0;
    foreach (int elemento in matriz)
    {
        soma += elemento;
    }
    Console.WriteLine($"Soma de todos os elementos: {soma}");
}

static void SomarLinhas(int[,] matriz)
{
    for (int i = 0; i < 3; i++)
    {
        int somaLinha = 0;
        for (int j = 0; j < 3; j++)
        {
            somaLinha += matriz[i, j];
        }
        Console.WriteLine($"Soma da linha {i}: {somaLinha}");
    }
}

static void SomarColunas(int[,] matriz)
{
    for (int j = 0; j < 3; j++)
    {
        int somaColuna = 0;
        for (int i = 0; i < 3; i++)
        {
            somaColuna += matriz[i, j];
        }
        Console.WriteLine($"Soma da coluna {j}: {somaColuna}");
    }
}

static void MostrarDiagonalPrincipal(int[,] matriz)
{
    Console.WriteLine("Diagonal Principal:");
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine(matriz[i, i]);
    }
}

```

## Exercício 8

```csharp
int[] numeros = new int[10];
Random random = new Random();

// Preenche o array com números aleatórios
for (int i = 0; i < numeros.Length; i++)
{
    numeros[i] = random.Next(1, 101);
}

bool continuar = true;
while (continuar)
{
    Console.WriteLine("\nArray original: " + string.Join(", ", numeros));

    // Escolher algoritmo de ordenação
    Console.WriteLine("Escolha um algoritmo de ordenação:");
    Console.WriteLine("1. Bubble Sort");
    Console.WriteLine("2. Selection Sort");
    Console.WriteLine("3. Insertion Sort");
    Console.WriteLine("4. Sair");
    string opcao = Console.ReadLine();

    if (opcao == "4")
    {
        continuar = false;
        continue;
    }

    // Escolher ordem
    Console.WriteLine("Escolha a ordem:");
    Console.WriteLine("1. Crescente");
    Console.WriteLine("2. Decrescente");
    bool crescente = Console.ReadLine() == "1";

    int trocas = 0;
    int[] numerosOrdenados = (int[])numeros.Clone();

    switch (opcao)
    {
        case "1":
            trocas = BubbleSort(numerosOrdenados, crescente);
            break;
        case "2":
            trocas = SelectionSort(numerosOrdenados, crescente);
            break;
        case "3":
            trocas = InsertionSort(numerosOrdenados, crescente);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("Array ordenado: " + string.Join(", ", numerosOrdenados));
    Console.WriteLine($"Trocas realizadas: {trocas}");
}

static int BubbleSort(int[] array, bool crescente)
{
    int trocas = 0;
    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = 0; j < array.Length - 1 - i; j++)
        {
            if (crescente ? array[j] > array[j + 1] : array[j] < array[j + 1])
            {
                Trocar(array, j, j + 1);
                trocas++;
            }
        }
    }
    return trocas;
}

static int SelectionSort(int[] array, bool crescente)
{
    int trocas = 0;
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minMax = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (crescente ? array[j] < array[minMax] : array[j] > array[minMax])
            {
                minMax = j;
            }
        }
        if (minMax != i)
        {
            Trocar(array, i, minMax);
            trocas++;
        }
    }
    return trocas;
}

static int InsertionSort(int[] array, bool crescente)
{
    int trocas = 0;
    for (int i = 1; i < array.Length; i++)
    {
        int chave = array[i];
        int j = i - 1;
        while (j >= 0 && (crescente ? array[j] > chave : array[j] < chave))
        {
            array[j + 1] = array[j];
            j--;
            trocas++;
        }
        array[j + 1] = chave;
    }
    return trocas;
}

static void Trocar(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}
```

## Exercício 9

```csharp
class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    public Pessoa(string nome, int idade, string cpf, string email)
    {
        Nome = nome;
        Idade = idade;
        CPF = cpf;
        Email = email;
    }

    public int CalcularIdadeEmMeses() => Idade * 12;

    public bool VerificarMaioridade() => Idade >= 18;

    public string FormatarCPF() => Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");

    public bool ValidarCPF() => CPF.Length == 11 && Regex.IsMatch(CPF, @"^\d+$");

    public bool ValidarEmail() => Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public bool ValidarIdade() => Idade >= 0 && Idade <= 150;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cadastro de Pessoas");
        Console.Write("Digite o nome: ");
        var nome = Console.ReadLine();

        Console.Write("Digite a idade: ");
        var idade = int.Parse(Console.ReadLine());

        Console.Write("Digite o CPF (somente números): ");
        var cpf = Console.ReadLine();

        Console.Write("Digite o email: ");
        var email = Console.ReadLine();

        Pessoa pessoa = new Pessoa(nome, idade, cpf, email);

        if (!pessoa.ValidarCPF())
        {
            Console.WriteLine("CPF inválido.");
            return;
        }

        if (!pessoa.ValidarEmail())
        {
            Console.WriteLine("Email inválido.");
            return;
        }

        if (!pessoa.ValidarIdade())
        {
            Console.WriteLine("Idade inválida.");
            return;
        }

        Console.WriteLine($"Pessoa cadastrada: {pessoa.Nome}");
        Console.WriteLine($"Idade em meses: {pessoa.CalcularIdadeEmMeses()}");
        Console.WriteLine($"Maioridade: {(pessoa.VerificarMaioridade() ? "Sim" : "Não")}");
        Console.WriteLine($"CPF formatado: {pessoa.FormatarCPF()}");
    }
}
```

## Exercício 10

```csharp
class Veiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public decimal Preco { get; set; }

    public Veiculo(string marca, string modelo, int ano, decimal preco)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Preco = preco;
    }

    public virtual decimal CalcularIPVA() => Preco * 0.04m;

    public virtual void ExibirInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Ano: {Ano}, Preço: {Preco:C}");
    }
}

class Carro : Veiculo
{
    public int NumeroPortas { get; set; }
    public string Tipo { get; set; }  // Sedan, SUV, etc.

    public Carro(string marca, string modelo, int ano, decimal preco, int numeroPortas, string tipo)
        : base(marca, modelo, ano, preco)
    {
        NumeroPortas = numeroPortas;
        Tipo = tipo;
    }

    public override decimal CalcularIPVA() => Preco * 0.03m;
    
    public override void ExibirInfo()
    {
        base.ExibirInfo();
        Console.WriteLine($"Portas: {NumeroPortas}, Tipo: {Tipo}");
    }
}

class Moto : Veiculo
{
    public int Cilindrada { get; set; }
    public string Tipo { get; set; }

    public Moto(string marca, string modelo, int ano, decimal preco, int cilindrada, string tipo)
        : base(marca, modelo, ano, preco)
    {
        Cilindrada = cilindrada;
        Tipo = tipo;
    }

    public override decimal CalcularIPVA() => Preco * 0.02m;

    public override void ExibirInfo()
    {
        base.ExibirInfo();
        Console.WriteLine($"Cilindrada: {Cilindrada}, Tipo: {Tipo}");
    }
}

class Program
{
    static void Main()
    {
        List<Veiculo> veiculos = new List<Veiculo>
        {
            new Carro("Toyota", "Corolla", 2020, 80000, 4, "Sedan"),
            new Moto("Honda", "CB 500", 2019, 30000, 500, "Street")
        };

        foreach (var veiculo in veiculos)
        {
            veiculo.ExibirInfo();
            Console.WriteLine($"IPVA: {veiculo.CalcularIPVA():C}");
        }
    }
}
```

## Exercício 11

```csharp
class ContaBancaria
{
    public decimal Saldo { get; private set; };
    private int _numeroConta;
    public List<string> HistoricoTransacoes { get; private set; }

    public ContaBancaria(int numeroConta)
    {
        _numeroConta = numeroConta;
        _saldo = 0;
        HistoricoTransacoes = new List<string>();
    }

    public void Depositar(decimal valor)
    {
        _saldo += valor;
        HistoricoTransacoes.Add($"Depósito de {valor:C}");
    }

    public bool Sacar(decimal valor)
    {
        if (_saldo >= valor)
        {
            _saldo -= valor;
            HistoricoTransacoes.Add($"Saque de {valor:C}");
            return true;
        }

        Console.WriteLine("Saldo insuficiente.");
        return false;
    }

    public void ExibirHistorico()
    {
        Console.WriteLine("Histórico de transações:");
        foreach (var transacao in HistoricoTransacoes)
            Console.WriteLine(transacao);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria(12345);
        conta.Depositar(1000);
        conta.Sacar(200);
        Console.WriteLine($"Saldo: {conta.ConsultarSaldo():C}");
        conta.ExibirHistorico();
    }
}
```

## Exercício 12

```csharp
abstract class Animal
{
    public string Nome { get; set; }
    public string Especie { get; set; }
    public int Idade { get; set; }

    public Animal(string nome, string especie, int idade)
    {
        Nome = nome;
        Especie = especie;
        Idade = idade;
    }

    public abstract void EmitirSom();
    public abstract void Movimentar();
}

class Leao : Mamifero
{
    public Leao(string nome, int idade) : base(nome, "Leão", idade) { }

    public override void EmitirSom() => Console.WriteLine($"{Nome} rugiu!");

    public override void Movimentar() => Console.WriteLine($"{Nome} correu rapidamente.");
}

class Papagaio : Ave
{
    public Papagaio(string nome, int idade) : base(nome, "Papagaio", idade) { }

    public override void EmitirSom() => Console.WriteLine($"{Nome} falou: 'Olá!'");

    public override void Movimentar() => Console.WriteLine($"{Nome} voou pelo céu.");
}

class Program
{
    static void Main()
    {
        List<Animal> zoologico = new List<Animal>
        {
            new Leao("Simba", 5),
            new Papagaio("Loro", 2)
        };

        foreach (var animal in zoologico)
        {
            animal.EmitirSom();
            animal.Movimentar();
        }
    }
}
```

## Exercício 13

```csharp
interface IPagamento
{
    bool Autorizar(decimal valor);
    bool EfetuarPagamento(decimal valor);
    bool EstornarPagamento(string idTransacao);
}

class PagamentoCredito : IPagamento
{
    private int parcelas;
    private decimal juros;

    public PagamentoCredito(int parcelas, decimal juros)
    {
        this.parcelas = parcelas;
        this.juros = juros;
    }

    public bool Autorizar(decimal valor)
    {
        // Lógica para autorização de crédito
        return true;
    }

    public bool EfetuarPagamento(decimal valor)
    {
        // Lógica para efetuar pagamento com parcelas e juros
        return true;
    }

    public bool EstornarPagamento(string idTransacao)
    {
        // Lógica para estorno
        return true;
    }
}

class PagamentoDebito : IPagamento
{
    public bool Autorizar(decimal valor)
    {
        // Lógica para verificar saldo
        return true;
    }

    public bool EfetuarPagamento(decimal valor)
    {
        // Lógica para efetuar pagamento se houver saldo
        return true;
    }

    public bool EstornarPagamento(string idTransacao)
    {
        // Lógica para estorno
        return true;
    }
}

class PagamentoPix : IPagamento
{
    private string chavePix;
    private string qrCode;

    public PagamentoPix(string chavePix, string qrCode)
    {
        this.chavePix = chavePix;
        this.qrCode = qrCode;
    }

    public bool Autorizar(decimal valor)
    {
        // Lógica
        return true;
    }

    public bool EfetuarPagamento(decimal valor)
    {
        // Lógica
        return true;
    }

    public bool EstornarPagamento(string idTransacao)
    {
        // Lógica
        return true;
    }
}

class ProcessadorPagamentos
{
    public void ProcessarPagamento(IPagamento pagamento, decimal valor)
    {
        if (pagamento.Autorizar(valor))
        {
            pagamento.EfetuarPagamento(valor);
        }
    }
}
```

## Exercício 14

```csharp
abstract class Forma
{
    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();
    public abstract int NumeroLados { get; }
}

 class Quadrado : Forma
{
    public double Lado { get; set; }

    public override double CalcularArea() => Lado * Lado;

    public override double CalcularPerimetro() => 4 * Lado;

    public override int NumeroLados => 4;
}

class Retangulo : Forma
{
    public double Largura { get; set; }
    public double Altura { get; set; }

    public override double CalcularArea() => Largura * Altura;

    public override double CalcularPerimetro() => 2 * (Largura + Altura);

    public override int NumeroLados => 4;
}

class Circulo : Forma
{
    public double Raio { get; set; }

    public override double CalcularArea() => Math.PI * Raio * Raio;

    public override double CalcularPerimetro() => 2 * Math.PI * Raio;

    public override int NumeroLados => 0;

class Triangulo : Forma
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public override double CalcularArea() => (Base * Altura) / 2;

    public override double CalcularPerimetro() => Base + 2 * Altura;

    public override int NumeroLados => 3;
}

interface IDesenhavel
{
    void Desenhar();
    void Redimensionar(double fator);
}

class ProgramaFormas
{
    public static void Main()
    {
        Forma quadrado = new Quadrado { Lado = 5 };
        Console.WriteLine($"Área do quadrado: {quadrado.CalcularArea()}");

        Forma circulo = new Circulo { Raio = 3 };
        Console.WriteLine($"Perímetro do círculo: {circulo.CalcularPerimetro()}");
    }
}
```

## Exercício 15

```csharp
interface IRepositorio<T>
{
    T ObterPorId(int id);
    IEnumerable<T> ObterTodos();
    void Adicionar(T entidade);
    void Atualizar(T entidade);
    void Remover(int id);
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class RepositorioProduto : IRepositorio<Produto>
{
    private List<Produto> produtos = new List<Produto>();

    public Produto ObterPorId(int id) => produtos.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Produto> ObterTodos() => produtos;

    public void Adicionar(Produto produto) => produtos.Add(produto);

    public void Atualizar(Produto produto)
    {
        var existente = ObterPorId(produto.Id);
        if (existente != null)
        {
            existente.Nome = produto.Nome;
            existente.Preco = produto.Preco;
        }
    }

    public void Remover(int id)
    {
        var produto = ObterPorId(id);
        if (produto != null)
        {
            produtos.Remove(produto);
        }
    }
}
```

## Exercício 16

```csharp
class DivisaoPorZeroException : Exception
{
    public DivisaoPorZeroException() : base("Divisão por zero não permitida.") { }
}

class OperacaoInvalidaException : Exception
{
    public OperacaoInvalidaException(string message) : base(message) { }
}

class NumeroMuitoGrandeException : Exception
{
    public NumeroMuitoGrandeException() : base("Número muito grande.") { }
}

class Calculadora
{
    public double Dividir(double a, double b)
    {
        if (b == 0)
            throw new DivisaoPorZeroException();
        return a / b;
    }

    public double Somar(double a, double b)
    {
        if (a > 1e6 || b > 1e6)
            throw new NumeroMuitoGrandeException();
        return a + b;
    }

    public double Subtrair(double a, double b)
    {
        return a - b;
    }

    public double Multiplicar(double a, double b)
    {
        return a * b;
    }
}

```

## Exercício 17

```csharp
class LeitorArquivo
{
    public void LerArquivo(string caminho)
    {
        try
        {
            var conteudo = File.ReadAllText(caminho);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Arquivo não encontrado: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro de IO: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Acesso não autorizado: {ex.Message}");
        }
    }
}
```

## Exercício 18

```csharp
var pessoas = new List<Pessoa>
{
    new Pessoa { Nome = "João", Idade = 30, Cidade = "São Paulo", Profissao = "Engenheiro", Salario = 5000 },
    // outras 19 pessoas...
};

// Todas as pessoas de uma cidade específica
var pessoasCidade = pessoas.Where(p => p.Cidade == "São Paulo");

// Média de idade por profissão
var mediaIdade = pessoas.GroupBy(p => p.Profissao)
                        .Select(g => new { Profissao = g.Key, MediaIdade = g.Average(p => p.Idade) });

// Maior e menor salário
var maiorSalario = pessoas.Max(p => p.Salario);
var menorSalario = pessoas.Min(p => p.Salario);

// Pessoas agrupadas por faixa etária
var agrupamentoIdade = pessoas.GroupBy(p => p.Idade / 10)
                              .Select(g => new { FaixaEtaria = g.Key * 10, Pessoas = g.ToList() });
```

## Exercício 19

```csharp
var resultado = from l in livros
                join a in autores on l.AutorId equals a.Id
                join c in categorias on l.CategoriaId equals c.Id
                where a.Nacionalidade == "Brasileira"
                group l by c.Nome into g
                select new {
                    Categoria = g.Key,
                    Quantidade = g.Count(),
                    ValorTotal = g.Sum(x => x.Preco)
                };
```

## Exercício 20 - Sistema de Gerenciamento de Concessionária

```csharp
// Lojas e a quantidade de carros por marca em cada loja
var query1 = context.Lojas
    .Select(loja => new
    {
        NomeLoja = loja.Nome,
        CarrosPorMarca = loja.Carros
            .GroupBy(c => c.Marca.Nome)
            .Select(g => new 
            { 
                Marca = g.Key, 
                Quantidade = g.Count() 
            })
    });

// 3 carros mais antigos de cada marca
var query2 = context.Marcas
    .Select(marca => new
    {
        Marca = marca.Nome,
        CarrosMaisAntigos = marca.Carros
            .OrderBy(c => c.Ano)
            .Take(3)
            .Select(c => new 
            { 
                c.Modelo, 
                c.Ano 
            })
    });

// Ano médio dos carros por loja e liste em ordem decrescente
var query3 = context.Lojas
    .Select(loja => new
    {
        Loja = loja.Nome,
        AnoMedio = loja.Carros.Average(c => c.Ano)
    })
    .OrderByDescending(x => x.AnoMedio);

// As lojas que têm carros de todas as marcas
var totalMarcas = context.Marcas.Count();
var query4 = context.Lojas
    .Where(loja => loja.Carros.Select(c => c.Marca.Id).Distinct().Count() == totalMarcas)
    .Select(loja => loja.Nome);

// Para cada marca, o número de lojas diferentes que vendem seus carros
var query5 = context.Marcas
    .Select(marca => new
    {
        Marca = marca.Nome,
        NumeroLojas = marca.Carros.Select(c => c.Loja.Id).Distinct().Count()
    });

// Identificar se existem modelos duplicados em marcas diferentes
var query6 = context.Carros
    .GroupBy(c => c.Modelo)
    .Where(g => g.Select(c => c.Marca.Id).Distinct().Count() > 1)
    .Select(g => new
    {
        Modelo = g.Key,
        Marcas = g.Select(c => c.Marca.Nome).Distinct()
    });

// Agrupar os carros por década e mostre a marca mais comum em cada década
var query7 = context.Carros
    .GroupBy(c => c.Ano / 10 * 10)
    .Select(g => new
    {
        Decada = $"{g.Key}s",
        MarcaMaisComum = g.GroupBy(c => c.Marca.Nome)
            .OrderByDescending(mg => mg.Count())
            .Select(mg => mg.Key)
            .FirstOrDefault()
    });

// As lojas que têm mais de 5 carros da mesma marca
var query8 = context.Lojas
    .Where(loja => loja.Carros
        .GroupBy(c => c.Marca.Id)
        .Any(g => g.Count() > 5))
    .Select(loja => new
    {
        Loja = loja.Nome,
        MarcasComMaisDe5 = loja.Carros
            .GroupBy(c => c.Marca.Nome)
            .Where(g => g.Count() > 5)
            .Select(g => new 
            { 
                Marca = g.Key, 
                Quantidade = g.Count() 
            })
    });

// Os carros ordenados por ano e modelo, pulando os 5 primeiros e limitando a 10 resultados
var query9 = context.Carros
    .OrderBy(c => c.Ano)
    .ThenBy(c => c.Modelo)
    .Skip(5)
    .Take(10)
    .Select(c => new 
    { 
        c.Modelo, 
        c.Ano, 
        Marca = c.Marca.Nome 
    });

// Objeto anônimo com estatísticas da loja
var query10 = context.Lojas
    .Select(loja => new
    {
        NomeLoja = loja.Nome,
        TotalCarros = loja.Carros.Count,
        CarroMaisNovo = loja.Carros.OrderByDescending(c => c.Ano)
            .Select(c => new { c.Modelo, c.Ano })
            .FirstOrDefault(),
        CarroMaisAntigo = loja.Carros.OrderBy(c => c.Ano)
            .Select(c => new { c.Modelo, c.Ano })
            .FirstOrDefault(),
        MarcasDistintas = loja.Carros
            .Select(c => c.Marca.Nome)
            .Distinct()
            .ToList()
    });
```
