
namespace relatorio2;
class Program
{ 
    static void Main(string[] args)
    {
        MetodosDoPrograma programa  = new MetodosDoPrograma();
        //Mensagens iniciais no console
        Console.WriteLine("Condicionais e laços");
        Console.WriteLine();
        //Identificadores case -sensitive
        programa.sensitiveCase();
        //Classificação por nota com if / else if / else 
        programa.Nota(95);
        //Comando com switch 
        programa.ComandoSwitch('B');
        //Contagem com o laço for 
        programa.Contador(10);
        //Contagem regressiva com o laço while 
        programa.ContadorRegressivo(5);
        string? valor_entrada = null;
        do
        {
            Console.WriteLine("\nEnter para encerrar o console.");
            valor_entrada = Console.ReadKey().Key.ToString();
        } while (valor_entrada != "Enter");
    }

}

