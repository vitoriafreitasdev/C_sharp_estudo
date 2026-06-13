namespace relatorio7
{
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
    class Program
    {
        static void Main(string[] args)
        {
            //Objeto derivado de Animal
            Animal animal = new Animal("Annie");
            //Objeto derivado de Cachorro
            Cachorro cachorro = new Cachorro("Johnny");
            //Objeto derivado de Gato
            Gato gato = new Gato("Kurt");
            //Lista de animais
            List<Animal> animais = new List<Animal>{ animal, cachorro, gato};
            animal.Comer();
            cachorro.AbanarRabo();
            gato.Arranhar();
            animais.ForEach(a => a.FazerSom());
        }
    }
}
