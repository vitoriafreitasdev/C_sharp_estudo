namespace relatorio5
{
    // Classe abstrata, que servirá de base para as outras
    public abstract class Animal { 
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public abstract void EmitirSom();
    }
    //Classes que herdam da Animal
    public class Cachorro : Animal
    {
        public string Name { get; set; }
        //Construtor, base faz referencia ao construtor da classe base
        public Cachorro(string name) : base(name)
        {
            Name = name;
        }
        public override void EmitirSom()
        {
            Console.WriteLine($"{Name}: Au au");
        }
    }
    public class Gato : Animal
    {
        public string Name { get; set; }

        public Gato(string name) : base(name)
        {
            Name = name;
        }

        public override void EmitirSom()
        {
            Console.WriteLine($"{Name}: Miau");
        }
    }
    public class Program
    {
        static void Main()
        {
            //Instancias da classes
            Cachorro bred = new Cachorro("Bred");
            Gato nala = new Gato("Nala");
            //Lista com os objetos criados acima
            List<Animal> animais = new List<Animal>{ bred, nala};
            //impressão do som de cada animal criado
            animais.ForEach(animal => animal.EmitirSom());
        }
    }
}

