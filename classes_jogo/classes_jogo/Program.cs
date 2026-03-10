using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;
abstract class Arma
{
    public abstract void Atacar();
}
class Espada : Arma
{
    public override void Atacar()
    {
        Console.WriteLine("Golpe de espada!");
    }
}
class Arco : Arma
{
    public override void Atacar()
    {
        Console.WriteLine("Disparo de flecha!");
    }
}
class Personagem
{
    public Arma ArmaAtual { get; set; }
    public Personagem(Arma armaInicial)
    {
        this.ArmaAtual = armaInicial;
    }
    public void Atacar()
    {
        if (ArmaAtual != null)
            ArmaAtual.Atacar();
        else
            Console.WriteLine("Personagem desarmado não pode atacar.");
    }
}

// composição 
class Character
{
    public string Name { get; set; }
    public Character(string name)
    {
        Name = name;
    }
    public virtual void Attack()
    {
        Console.WriteLine($"{ Name} ataca de forma genérica.");
    }
}
class Warrior : Character
{
    public Warrior(string name) : base(name) { }
    public override void Attack()
    {
        Console.WriteLine($"{ Name} avança com sua espada, desferindo um golpe poderoso!");
    }
}
class Mage : Character
{
    public Mage(string name) : base(name) { }
    public override void Attack()
    {
        Console.WriteLine($"{ Name} lança uma bola de fogo ardente contra o inimigo!");
    }
}
class Program
{
    static void Main()
    {
        Personagem heroi = new Personagem(new Espada());
        heroi.Atacar(); // Saída: Golpe de espada!
        heroi.ArmaAtual = new Arco();
        heroi.Atacar(); // Saída: Disparo de flecha!

        Character[] party = new Character[2];
        party[0] = new Warrior("Arus");
        party[1] = new Mage("Luna");
        foreach (Character member in party)
        {
            member.Attack();
        }
    }
}