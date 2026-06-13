public record Prod
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public double Preco { get; init; }

};
public class Cliente
{
    public decimal Total { get; set; }
}
public class Configuracao
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
namespace relatorio1
{
    class Program
    {
        static void Main()
        {
            //Imprimindo uma saldação na tela
            Console.WriteLine("Olá, Tudo bem?");
            //Declarando variáveis tipos por valor
            int idade = 21;
            string nome = "João";
            Console.WriteLine($"Meu nome é {nome} e tenho {idade} anos.");
            //Nullabilidade
            string? texto = null;
            string exibicao = texto ?? "Sem valor atribuído";
            Console.WriteLine(exibicao);
            //Caso o texto seja nulo, atribui um valor padrão
            texto ??= "Hoje está um dia bonito";
            Console.WriteLine(texto);
            //switch como expressão
            object? numero = 120;
            string desc = numero switch
            {
                null => "Valor é nulo",
                string => "Valor agregado é uma string",
                int x when x > 150 => "Valor inteiro maior que 150",
                _ => "Valor não encontrado"
            };
            Console.WriteLine(desc);
            //Função local static
            static decimal calculo(decimal preco, decimal valor = 0.12m) => preco * valor;
            decimal res = calculo(100.2m);
            Console.WriteLine(res);
            //record
            var p1 = new Prod
            {
                Id = 1,
                Nome = "Celular",
                Preco = 1240.05
            };
            var p2 = p1 with { Preco = 1300.00 };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            //Classe com propriedade e o token contextual field
            var novaConfiguracao = new Configuracao();
            novaConfiguracao.Tema = "Vermelho";
            Console.WriteLine(novaConfiguracao.Tema);
            //Classe Cliente e atribuição condicional com ?. no destino
            Cliente? cliente = new Cliente();
            cliente?.Total += 120.50m;
            Console.WriteLine(cliente?.Total);
        }
    }
}
