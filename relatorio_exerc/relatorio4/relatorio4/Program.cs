//Program.cs
namespace relatorio4
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta = new ContaBancaria(200m);
            Console.WriteLine("Saldo: " + conta.Saldo);
            //Teste - valores inválidos  
            bool res1 = conta.Depositar(0m);
            bool res2 = conta.Sacar(0m);
            bool res3 = conta.Sacar(300m);
            Console.WriteLine(res1 + "\n" + res2 + "\n" + res3);
            Console.WriteLine("Saldo: " + conta.Saldo);
            //Teste - valores válidos  
            bool res4 = conta.Depositar(150m);
            bool res5 = conta.Sacar(20m);
            bool res6 = conta.Sacar(100m);
            Console.WriteLine(res4 + "\n" + res5 + "\n" + res6);
            Console.WriteLine("Saldo " + conta.Saldo);
        }
    }
}


