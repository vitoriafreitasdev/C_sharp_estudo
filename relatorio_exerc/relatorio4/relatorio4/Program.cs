//Program.cs
namespace relatorio4
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta = new ContaBancaria(200m);
            Console.WriteLine("Saldo inicial: " + conta.Saldo);
            //Testes com os parâmetros sendo valores inválidos  
            bool resultadoDepositoErrado = conta.Depositar(0m);
            bool resultadoSaqueErrado1 = conta.Sacar(0m);
            bool resultadoSaqueErrado2 = conta.Sacar(300m);
            Console.WriteLine(resultadoDepositoErrado + "\n" + resultadoSaqueErrado1 + "\n" + resultadoSaqueErrado2);
            Console.WriteLine("Saldo após as transições: " + conta.Saldo);
            //Testes com os parâmetros sendo valores válidos  
            bool resultadoDepositoCerto = conta.Depositar(150m);
            bool resultadoSaqueCerto1 = conta.Sacar(20m);
            bool resultadoSaqueCerto2 = conta.Sacar(100m);
            Console.WriteLine(resultadoDepositoCerto + "\n" + resultadoSaqueCerto1 + "\n" + resultadoSaqueCerto2);
            Console.WriteLine("Saldo após as transições: " + conta.Saldo);
        }
    }
}


