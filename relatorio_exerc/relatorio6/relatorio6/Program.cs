//Program.cs
namespace relatorio6
{
    class Retangulo : IForma
    {
        public double Largura {  get; set; }
        public double Altura { get; set; }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }
        public double CalcularArea()
        {
            return Largura * Altura; // formula => base x altura
        }
        public double CalcularPerimetro()
        {
            return Largura + Altura + Largura + Altura; // formula => soma de todos os lados
        }
    }

    class Circulo : IForma
    {
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            Raio = raio; 
        }
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2); // formula => π x r ao quadrado.
        }
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio; // formula => 2π x r.
        }
    }
    class Program
    { 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o valor da largura do retangulo: ");
            string? LarguraRet = Console.ReadLine();
            Console.WriteLine("Insira o valor da altura do retangulo: ");
            string? AlturaRet = Console.ReadLine();
            Console.WriteLine("Insira o valor do raio do circulo: ");
            string? CirculoRaio = Console.ReadLine();
            //If para certificar que os valores recebidos não são nulos
            if (LarguraRet != null && AlturaRet != null && CirculoRaio != null)
            {
                Retangulo retangulo = new Retangulo(double.Parse(LarguraRet), double.Parse(AlturaRet));
                Circulo circulo = new Circulo(double.Parse(CirculoRaio));
                List<IForma> formas = new List<IForma>{ retangulo, circulo};
                formas.ForEach(x =>
                {
                    Console.WriteLine(x.CalcularArea().ToString("F2")); // retorno em 2 casas decimais
                    Console.WriteLine(x.CalcularPerimetro().ToString("F2")); // retorno em 2 casas decimais
                });
            }

            
        }

    }
}

