namespace relatorio5
{
    // Classe abstrata
    public abstract class Animal { 
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public abstract void EmitirSom();
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

    public class Cachorro : Animal
    {
        public string Name { get; set; }
        //Construtor faz referencia a outro construtor 
        public Cachorro(string name) : base(name)
        {
            Name = name;
        }
        public override void EmitirSom()
        {
            Console.WriteLine($"{Name}: Au au");
        }
    }
    public class Program
    {
        static void Main()
        {
            //Objetos criados a partir das classes Cachorro e Gato
            Cachorro max = new Cachorro("Max");
            Gato Snow = new Gato("Nala");
            //Listas de animais criados a partir da classe abstrata Animal
            List<Animal> bichos = new List<Animal>{ max, Snow };
            //Emissão do som de cada animal usando o método EmitirSom() da classe abstrata Animal
            bichos.ForEach(animal => animal.EmitirSom());
        }
    }
}

