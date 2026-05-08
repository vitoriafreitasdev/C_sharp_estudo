namespace relatorio7
{
    //Classe Base: Animal
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }
        
        public void Comer()
        {
            Console.WriteLine($"Animal {Name} está comendo.");
        }

        public virtual void FazerSom()
        {
            Console.WriteLine($"Animal {Name} está fazendo um som.");
        }
    }
    //Classes derivas: Cachorro e Gato
    class Cachorro : Animal
    {
        public Cachorro(string name) : base(name)
        {
            Name = name;
        }

        public void AbanarRabo()
        {
            Console.WriteLine($"Cachorro {Name} está abanando o rabo.");
        }

        public override void FazerSom()
        {
            Console.WriteLine($"Cachorro {Name} fez um som: au au.");
        }

    }

    class Gato : Animal
    {
        public Gato(string name) : base(name)
        {
            Name = name;
        }

        public void Arranhar()
        {
            Console.WriteLine($"Gato {Name} está arranhando o arranhador.");
        }

        public override void FazerSom()
        {
            Console.WriteLine($"Gato {Name} fez um som: miau.");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Animal instância
            Animal animal = new Animal("Max");
            //Cachorro instância
            Cachorro cachorro = new Cachorro("Fred");
            //Gato instância
            Gato gato = new Gato("Scar");
            //Lista de animais
            List<Animal> animais = new List<Animal>{ animal, cachorro, gato};
            animal.Comer();
            cachorro.AbanarRabo();
            gato.Arranhar();
            //ForEach para executar o método FazerSom em cada objeto tipo Animal
            animais.ForEach(a => a.FazerSom());
        }
    }
}
