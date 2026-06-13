//Program.cs
namespace relatorio6
{
    class Retangulo : IForma
    {
        public double Larg {  get; set; }
        public double Alt { get; set; }

        public Retangulo(double largura, double altura)
        {
            Larg = largura;
            Alt = altura;
        }
        public double CalcularArea()
        {
            return Larg * Alt; 
        }
        public double CalcularPerimetro()
        {
            return Larg + Alt + Larg + Alt; 
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
            return Math.PI * Math.Pow(Raio, 2); 
        }
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }
    }
    class Program
    { 
        
        static void Main(string[] args)
        {
            // Solicitar ao usuário as medidas do retângulo e do círculo
            Console.WriteLine("Largura do retangulo: ");
            string? lRet = Console.ReadLine();
            Console.WriteLine("Altura do retangulo: ");
            string? aRet = Console.ReadLine();
            Console.WriteLine("Raio do circulo: ");
            string? cRaio = Console.ReadLine();
     
            Retangulo ret = new Retangulo(double.Parse(lRet), double.Parse(aRet));
            Circulo cir= new Circulo(double.Parse(cRaio));
            List<IForma> formas = new List<IForma>{ ret, cir};
            formas.ForEach(forma =>
            {
                Console.WriteLine(forma.CalcularArea()); 
                Console.WriteLine(forma.CalcularPerimetro());
            });
            
        }

    }
}

