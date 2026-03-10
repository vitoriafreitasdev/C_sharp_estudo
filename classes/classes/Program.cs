using System.Data;
using System.Runtime.Intrinsics.X86;



public class ContaBancaria
{
    private decimal saldo; // campo privado
    public decimal Saldo // propriedade pública somente leitura
    {
        get { return saldo; }
        private set { saldo = value; }
    }
    public ContaBancaria(decimal saldoInicial = 0m)
    {
        saldo = saldoInicial;
    }
    public bool Depositar(decimal quantia)
    {
        if (quantia <= 0)
            return false;
        saldo += quantia;
        return true;
    }
    public bool Sacar(decimal quantia)
    {
        if (quantia <= 0 || quantia > saldo)
            return false;
        saldo -= quantia;
        return true;
    }
}

// Classe abstrata representando um Animal genérico
public abstract class Animal
{
    public string Nome { get; set; }
    // Construtor da classe abstrata
    public Animal(string nome)
    {
        Nome = nome;
    }
    // Método abstrato: cada subclasse deve implementar o seu próprio som
    public abstract void EmitirSom();
}
// Subclasse concreta que estende Animal
public class Cachorro : Animal
{
    public Cachorro(string nome) : base(nome) { }
    // Implementação específica do som de um cachorro
    public override void EmitirSom()
    {
        Console.WriteLine($"{ Nome}: Au Au!");
    }
}
// Outra subclasse concreta de Animal
public class Gato : Animal
{
    public Gato(string nome) : base(nome) { }
    // Implementação específica do som de um gato
    public override void EmitirSom()
    {
        Console.WriteLine($"{ Nome}: Miau!");
    }
}

// Interface representando uma forma geométrica
public interface IForma
{
    double CalcularArea();
    double CalcularPerimetro();
}
// Classe concreta Retangulo implementa a interface IForma
public class Retangulo : IForma
{
    public double Largura { get; set; }
    public double Altura { get; set; }
    public Retangulo(double largura, double altura)
    {
        Largura = largura;
        Altura = altura;
    }
    public double CalcularArea()
    {
        return Largura * Altura;
    }
    public double CalcularPerimetro()
    {
        return 2 * (Largura + Altura);
    }
}
// Classe concreta Circulo implementa a interface IForma
public class Circulo : IForma
{
    public double Raio { get; set; }
    public Circulo(double raio)
    {
        Raio = raio;
    }
    public double CalcularArea()
    {
        return Math.PI * Raio * Raio;
    }
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Raio;
    }
}

class Animal2
{
    public string Nome { get; set; }
    public void Comer()
    {
        Console.WriteLine($"{ Nome} está comendo.");
    }
    public virtual void FazerSom()
    {
        Console.WriteLine("Som de animal genérico");
    }
}
class Cachorro2 : Animal2
{
    public void AbanarRabo()
    {
        Console.WriteLine($"{Nome} tá abanando o rabo.");
    }
    public override void FazerSom()
    {
        Console.WriteLine("Au Au!");
    }
    
}


// Classe abstrata

// Classe abstrata base
public abstract class Forma
{
    public string Nome { get; protected set; }
    // Construtor da classe abstrata base
    protected Forma(string nome)
    {
        Nome = nome;
    }
    // Membro abstrato: nenhuma implementação aqui
    public abstract double CalcularArea();
    // Método concreto: implementado na classe abstrata
    public void Descrever()
    {
        Console.WriteLine($"Esta forma é um { Nome}.");
    }
}
// Subclasse concreta da forma
public class Circulo3 : Forma
{
    private double raio;

    public Circulo3(double raio) : base("círculo")
    {
        this.raio = raio;
    }
    // Implementação obrigatória do método abstrato
    public override double CalcularArea()
    {
        return Math.PI * raio * raio;
    }
}
// Outra subclasse concreta
public class Retangulo3 : Forma
{
    private double largura, altura;
    public Retangulo3(double largura, double altura) : base("retângulo")
    {
        this.largura = largura;
        this.altura = altura;
    }
    public override double CalcularArea()
    {
        return largura * altura;
    }
}


// interface 

public interface IForma2
{
    double CalcularArea();
}

public class Triangulo : IForma2
{
    public double Base { get; set; }
    public double Altura { get; set; }
    public Triangulo(double b, double h)
    {
        Base = b;
        Altura = h;
    }
    public double CalcularArea()
    {
        return (Base * Altura) / 2.0;
    }
}

interface IFormaGeometrica
{
    double CalcularArea();
}
class Retangulo2 : IFormaGeometrica
{
    public double Largura { get; set; }
    public double Altura { get; set; }
    public double CalcularArea()
    {
        return Largura * Altura;
    }
}
class Circulo2 : IFormaGeometrica
{
    public double Raio { get; set; }
    public double CalcularArea()
    {
        return Math.PI * Raio * Raio;
    }
}


// interface e LSP

class Retangulo5
{
    public virtual void DefinirLargura(double larg) { Largura = larg; }
    public virtual void DefinirAltura(double alt) { Altura = alt; }
    public double Largura { get; protected set; }
    public double Altura { get; protected set; }
    public virtual double Area => Largura * Altura;
}
class Quadrado5 : Retangulo5
{
    public override void DefinirLargura(double larg)
    {
        base.DefinirLargura(larg);
        base.DefinirAltura(larg);
    }
    public override void DefinirAltura(double alt)
    {
        base.DefinirAltura(alt);
        base.DefinirLargura(alt);
    }
}

interface IGreetingsEn
{
    string Saudar();
}
interface IGreetingsFr
{
    string Saudar();
}
class CumprimentoMulti : IGreetingsEn, IGreetingsFr
{
    // Implementação implícita para inglês:
    public string Saudar()
    {
        return "Hello"; // Saudação em inglês por padrão
    }
    // Implementação explícita para francês:
    string IGreetingsFr.Saudar()
    {
        return "Bonjour"; // Saudação em francês somente via interface IGreetingsFr
    }
}
public class Program
{
    public static void Main()
    {
        Animal meuAnimal1 = new Cachorro("Rex");
        Animal meuAnimal2 = new Gato("Felix");
        Animal2 animal3 = new Cachorro2();

        animal3.Nome = "Bred";

        animal3.FazerSom();
        // Mesmo sem saber exatamente o tipo, podemos chamar EmitirSom graças à abstração
        meuAnimal1.EmitirSom(); // Saída: “Rex: Au Au!”
        meuAnimal2.EmitirSom(); // Saída: “Felix: Miau!”

        List<IForma> formas = new List<IForma>();
        formas.Add(new Retangulo(3.0, 4.0));
        formas.Add(new Circulo(5.0));
        foreach (IForma forma in formas)
        {
            Console.WriteLine($"Área: {forma.CalcularArea()}");
            Console.WriteLine($"Perímetro: {forma.CalcularPerimetro()}");
        }

        Forma f1 = new Circulo3(2.5);
        Forma f2 = new Retangulo3(3.0, 4.0);
        Console.WriteLine(f1.CalcularArea()); // Chama Circulo.CalcularArea()
        Console.WriteLine(f2.CalcularArea()); // Chama Retangulo.CalcularArea()
        f1.Descrever(); // Usa Forma.Descrever() para um círculo
        f2.Descrever(); // Usa Forma.Descrever() para um retângulo

        double AreaTotal(IFormaGeometrica[] formas)
        {
            double soma = 0;
            foreach (IFormaGeometrica forma in formas)
            {
                soma += forma.CalcularArea();
            }
            return soma;
        }

        // Uso do método:
        var formas2 = new IFormaGeometrica[] {
            new Retangulo2 { Largura = 5, Altura = 4 }, // área = 20
            new Circulo2 { Raio = 3 } // área ≈ 28.27
        };
        Console.WriteLine(AreaTotal(formas2)); // Saída esperada ≈ 48.27
                                               // Programa principal para testar as classes anteriores

        void AumentarRetanguloEmDobro(Retangulo5 r)
        {
            r.DefinirLargura(r.Largura * 2);
            r.DefinirAltura(r.Altura * 2);
            // Esperamos que a área agora seja quatro vezes maior:
            Console.WriteLine("Área quadruplicada: " +r.Area);
        }
        // Cenário de uso:
        Retangulo5 meuRet = new Retangulo5();
        meuRet.DefinirLargura(5);
        meuRet.DefinirAltura(10);
        // Área inicial = 50
        AumentarRetanguloEmDobro(meuRet);
        // Área esperada = 200 (50 * 4) -> correto para Retangulo
        Retangulo5 meuQuad = new Quadrado5();
        meuQuad.DefinirLargura(5);
        meuQuad.DefinirAltura(10);
        // Aqui, ao definir altura para 10, a largura também se torna 10 (Quadrado impõe lados iguais)
        // Área inicial de meuQuad = 100 (10*10)
        AumentarRetanguloEmDobro(meuQuad);
        // O método AumentarRetanguloEmDobro presume área quadruplicada,
        // mas para Quadrado a área resultante será 400 (pois os lados dobraram de 10 para 20, área 20 * 20)
     }
 }