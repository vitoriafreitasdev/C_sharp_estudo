public record Produto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public double Preco { get; init; }

};
public class Config
{
    private string _tema;
    public string Tema
    {
        get => _tema;

        set
        {
            if (value == null) throw new ArgumentNullException("Valor nulo é inválido.");
            _tema = value;
        }
    }

}
public class Cliente
{
    public decimal Total { get; set; }
}
namespace relatorio1
{
    class Program
    {
        static void Main()
        {
            //Etapa - 1: Imprimindo uma saldação na tela
            Console.WriteLine("Olá, bom dia");
            //Etapa - 2: Declarando variáveis tipos por valor
            int idade = 19;
            string nome = "Isaac";
            Console.WriteLine($"Olá, meu nome é {nome} e tenho {idade} anos.");
            //Etapa 3 - Nullabilidade
            string? frase = null;
            string exibir = frase ?? "Valor não atribuído";
            Console.WriteLine(exibir);
            frase ??= "O dia está ótimo";
            Console.WriteLine(frase);
            //Etapa 4 - switch como expressão
            object? valor = 120;
            string descricao = valor switch
            {
                null => "Valor nulo",
                string => "Valor é uma string",
                int x when x > 100 => "Valor inteiro maior que 100",
                _ => "Valor não encontrado"
            };
            Console.WriteLine(descricao);
            //Etapa 5 - Função local static
            static decimal Calc(decimal preco, decimal valor = 0.12m) => preco * valor;
            decimal resultado = Calc(100.2m);
            Console.WriteLine(resultado);
            //Etapa 6 - record
            var p1 = new Produto
            {
                Id = 1,
                Nome = "Celular",
                Preco = 1240.05
            };
            var p2 = p1 with { Preco = 1300.00 };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            //Etapa 7 - Classe com propriedade e o token contextual field
            var newConfig = new Config();
            newConfig.Tema = "Azul";
            Console.WriteLine(newConfig.Tema);
            //Etapa 8 - Classe Cliente e atribuição condicional com ?. no destino
            Cliente? cliente = new Cliente();
            cliente?.Total += 100.50m;
            Console.WriteLine(cliente?.Total);
        }
    }
}
