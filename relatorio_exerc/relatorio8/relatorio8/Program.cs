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
namespace relatorio8
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Criando instâncias de Animal, Cachorro e Gato
            Animal animal1 = new Animal();
            animal1.Name = "Leão";
 
            Animal animal2 = new Cachorro();
            animal2.Name = "Marley";

            Gato gato = new Gato();
            gato.Name = "Gar";
         
            List<Animal> animais = new List<Animal> { animal1, animal2, gato };
          
            animais.ForEach(a => a.FazerSom());
         
            animal1.Comer();
            //Não compila, porque o animal2 foi criado como tipo Animal, e Animal não tem o método AbanarRabo
          /*  animal2.AbanarRabo(); */
            //Casting
            Cachorro cachorro = (Cachorro)animal2;
            cachorro.AbanarRabo();
            //ou podemos fazer assim: 
            ((Cachorro)animal2).AbanarRabo();
            gato.Arranhar();
        }
    }
}
