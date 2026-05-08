namespace relatorio8
{
    //Classe Base: Animal
    class Animal
    {
        public string Name { get; set; }

        public void Comer()
        {
            Console.WriteLine($"Animal {Name} está comendo.");
        }

        public virtual void FazerSom()
        {
            Console.WriteLine($"Animal {Name} está fazendo um som genérico.");
        }
    }
    //Classes derivas: Cachorro e Gato
    class Cachorro : Animal
    {
       
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
            Animal animal1 = new Animal();
            animal1.Name = "Max";
            //Cachorro instância
            Animal animal2 = new Cachorro();
            animal2.Name = "Fred";
            //Gato instância
            Gato gato = new Gato();
            gato.Name = "Scar";
            //Lista de animais
            List<Animal> animais = new List<Animal> { animal1, animal2, gato };
            //ForEach para executar o método FazerSom em cada objeto tipo Animal
            animais.ForEach(a => a.FazerSom());
            //Compila, pois Comer existe na classe base
            animal1.Comer();
            //Não compila, porque o animal2 foi criado como tipo Animal, e Animal não tem o método AbanarRabo
            //animal2.AbanarRabo();
            //Realizando o Casting
            Cachorro cachorro = (Cachorro)animal2;
            cachorro.AbanarRabo();
            //ou podemos fazer assim: 
            ((Cachorro)animal2).AbanarRabo();
            gato.Arranhar();
        }
    }
}
