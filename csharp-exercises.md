## Exercícios C#

### Conceitos Básicos
1. **Hello World Personalizado**
   - Crie um programa que solicite o nome do usuário via console
   - Após receber o nome, imprima "Hello, [nome]!" 
   - Adicione a data e hora atual à mensagem
   - Exemplo de saída: "Hello, João! Agora são 14:30 do dia 08/10/2024."

2. **Calculadora Interativa**
   - Desenvolva uma calculadora que:
     - Solicite dois números ao usuário
     - Pergunte qual operação deseja realizar (adição, subtração, multiplicação ou divisão)
     - Realize a operação e mostre o resultado
   - Considere as seguintes validações:
     - Não permitir divisão por zero
     - Verificar se os valores inseridos são números válidos
   - Após mostrar o resultado, pergunte se o usuário deseja fazer outro cálculo

3. **Conversor de Temperatura Completo**
   - Crie um programa que:
     - Ofereça um menu com opções:
       1. Converter de Celsius para Fahrenheit
       2. Converter de Fahrenheit para Celsius
       3. Sair
     - Implemente as fórmulas:
       - C = (F - 32) * 5/9
       - F = C * 9/5 + 32
   - Mostre o resultado com duas casas decimais
   - Permita múltiplas conversões até o usuário escolher sair

4. **Tabuada Interativa**
   - Desenvolva um programa que:
     - Solicite um número inteiro entre 1 e 20
     - Mostre a tabuada completa desse número (multiplicação de 1 a 10)
     - Formate a saída de forma tabular, alinhada à direita
   - Exemplo de saída para o número 7:
     ```
     7 x 1  = 7
     7 x 2  = 14
     7 x 3  = 21
     ...
     7 x 10 = 70
     ```
   - Adicione uma opção para o usuário escolher outro número ou sair

### Arrays e Estruturas de Controle
5. **Gerenciador de Notas**
   - Crie um programa que:
     - Permita ao usuário inserir o nome de 5 alunos
     - Para cada aluno, permita inserir 4 notas bimestrais
     - Armazene esses dados em arrays
   - Calcule e mostre:
     - A média de cada aluno
     - A situação (Aprovado se média >= 7, Recuperação se média >= 5 e < 7, Reprovado se média < 5)
     - A média geral da turma
   - Use estruturas de repetição adequadas
   - Formate a saída em formato tabular

6. **Sistema de Busca Avançada**
   - Desenvolva um programa que:
     - Crie um array com 15 números inteiros aleatórios entre 1 e 100
     - Implemente três tipos de busca:
       1. Busca por valor exato
       2. Busca por valor maior que
       3. Busca por valor menor que
     - Mostre quantas ocorrências foram encontradas
     - Indique as posições de cada ocorrência no array
   - Ordene e mostre o array antes de realizar as buscas

7. **Manipulador de Matriz**
   - Crie um programa que:
     - Permita ao usuário preencher uma matriz 3x3 com números inteiros
     - Ofereça um menu de operações:
       1. Mostrar a matriz original
       2. Mostrar a matriz transposta
       3. Somar todos os elementos
       4. Mostrar a soma de cada linha
       5. Mostrar a soma de cada coluna
       6. Mostrar a diagonal principal
       7. Sair
   - Use métodos separados para cada operação
   - Formate a exibição da matriz de forma clara e organizada

8. **Ordenação Múltipla**
   - Implemente um programa que:
     - Crie um array de 10 números inteiros aleatórios
     - Ofereça diferentes algoritmos de ordenação:
       1. Bubble Sort
       2. Selection Sort
       3. Insertion Sort
     - Mostre o array antes e depois da ordenação
     - Permita escolher ordenação crescente ou decrescente
     - Mostre quantas trocas foram realizadas em cada algoritmo

### Orientação a Objetos
9. **Sistema de Cadastro de Pessoas**
   - Crie uma classe Pessoa com:
     - Propriedades:
       - Nome (string)
       - Idade (int)
       - CPF (string)
       - Email (string)
     - Métodos:
       - CalcularIdadeEmMeses()
       - VerificarMaioridade()
       - FormatarCPF() // Formato: XXX.XXX.XXX-XX
   - Implemente validações:
     - CPF com 11 dígitos
     - Email com formato válido
     - Idade entre 0 e 150
   - Crie um programa que use esta classe para cadastrar e exibir informações de várias pessoas

10. **Concessionária de Veículos**
    - Desenvolva um sistema com:
      - Classe base Veiculo:
        - Propriedades: Marca, Modelo, Ano, Preço
        - Métodos: CalcularIPVA(), ExibirInfo()
      - Classes derivadas:
        - Carro: adiciona NumeroPortas, Tipo (Sedan, SUV, etc)
        - Moto: adiciona Cilindrada, Tipo (Street, Custom, etc)
      - Implemente:
        - Diferentes cálculos de IPVA para cada tipo
        - Método para calcular valor de revenda
        - Cadastro e listagem de veículos

11. **Sistema Bancário**
    - Crie um sistema com:
      - Classe ContaBancaria:
        - Propriedades privadas: _saldo, _numeroConta
        - Métodos públicos: Depositar(), Sacar(), ConsultarSaldo()
      - Implemente:
        - Validação de saldo suficiente para saque
        - Histórico de transações
        - Diferentes tipos de conta (Corrente, Poupança) com regras específicas
      - Crie um menu interativo para operar as contas

12. **Zoológico Virtual**
    - Implemente um sistema com:
      - Classe abstrata Animal:
        - Propriedades: Nome, Especie, Idade
        - Métodos abstratos: EmitirSom(), Movimentar()
      - Classes derivadas: Mamifero, Ave, Reptil
      - Classes específicas: Leao, Papagaio, Cobra, etc
      - Crie um zoológico que:
        - Cadastre diferentes animais
        - Exiba informações específicas de cada um
        - Demonstre o polimorfismo com os métodos abstratos

## Interfaces e Abstração
13. **Processador de Pagamentos**
    - Crie uma interface IPagamento com métodos:
      - Autorizar(decimal valor)
      - EfetuarPagamento(decimal valor)
      - EstornarPagamento(string idTransacao)
    - Implemente a interface para:
      - PagamentoCredito (parcelas, juros)
      - PagamentoDebito (verificação de saldo)
      - PagamentoPix (chave pix, QRCode)
    - Crie um sistema que processe pagamentos usando estas implementações

14. **Calculadora de Formas Geométricas**
    - Desenvolva:
      - Classe abstrata Forma:
        - Métodos abstratos: CalcularArea(), CalcularPerimetro()
        - Propriedade abstrata: NumeroLados
      - Classes derivadas:
        - Quadrado, Retangulo, Circulo, Triangulo
      - Interface IDesenhavel:
        - Métodos: Desenhar(), Redimensionar()
    - Crie um programa que:
      - Permita criar diferentes formas
      - Calcule áreas e perímetros
      - Demonstre o uso da interface

15. **Gerenciador de Dados Genérico**
    - Crie uma interface genérica IRepositorio<T>:
      ```csharp
      public interface IRepositorio<T>
      {
          T ObterPorId(int id);
          IEnumerable<T> ObterTodos();
          void Adicionar(T entidade);
          void Atualizar(T entidade);
          void Remover(int id);
      }
      ```
    - Implemente a interface para duas entidades diferentes (ex: Produto e Cliente)
    - Crie um sistema que utilize estas implementações
    - Adicione funcionalidades de:
      - Pesquisa
      - Ordenação
      - Paginação

### Tratamento de Exceções
16. **Calculadora com Exceções Personalizadas**
    - Crie uma calculadora que:
      - Lance exceções personalizadas para:
        - DivisaoPorZeroException
        - OperacaoInvalidaException
        - NumeroMuitoGrandeException
      - Implemente um log de erros
      - Use blocos try-catch-finally
      - Permita que o programa continue rodando após erros

17. **Leitor de Arquivos**
    - Desenvolva um programa que:
      - Leia um arquivo texto e faça operações:
        - Contar palavras
        - Encontrar palavras específicas
        - Substituir texto
      - Trate as seguintes exceções:
        - FileNotFoundException
        - IOException
        - UnauthorizedAccessException
      - Implemente:
        - Retry logic para operações que podem falhar
        - Logging de todas as operações e erros
        - Limpeza adequada de recursos

### LINQ
18. **Processador de Dados com LINQ**
    - Crie uma lista de 20 pessoas com:
      - Nome, Idade, Cidade, Profissão, Salário
    - Implemente consultas LINQ para:
      - Encontrar todas as pessoas de uma cidade específica
      - Calcular a média de idade por profissão
      - Encontrar o maior e menor salário
      - Agrupar pessoas por faixa etária
    - Use diferentes sintaxes LINQ (query e method)

19. **Gerenciador de Biblioteca**
    - Crie classes: Livro, Autor, Categoria
    - Implemente relacionamentos entre elas
    - Use LINQ para:
      - Juntar dados de diferentes listas
      - Criar consultas complexas com múltiplos joins
      - Realizar operações de agregação
    - Exemplo de consulta:
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

20. **Sistema de Gerenciamento de Concessionária**
    - Na sua maquina, abra o projeto "ExemploLinq" disponível em: 
    https://drive.google.com/drive/folders/1uvy6DsyR9oHfTKvDFSNKWTghrYXzQ5NE?usp=drive_link
    - Abra a classe "Exercicio.cs"
    - Utilizando o modelo de dados fornecido (Carro, Loja, Marca), implemente as seguintes consultas LINQ em cada um dos seus respectivos métodos:
      1. Liste todas as lojas e a quantidade de carros por marca em cada loja
      2. Encontre os 3 carros mais antigos de cada marca
      3. Calcule o ano médio dos carros por loja e liste em ordem decrescente
      4. Encontre todas as lojas que têm carros de todas as marcas
      5. Para cada marca, mostre o número de lojas diferentes que vendem seus carros
      6. Identifique se existem modelos duplicados (mesmo nome) em marcas diferentes
      7. Agrupe os carros por década e mostre a marca mais comum em cada década
      8. Encontre lojas que têm mais de 5 carros da mesma marca
      9. Liste os carros ordenados por ano e modelo, pulando os 5 primeiros e limitando a 10 resultados
      10. Crie uma consulta que retorne um objeto anônimo com:
          - Nome da loja
          - Número total de carros
          - Carro mais novo
          - Carro mais antigo
          - Lista de marcas distintas