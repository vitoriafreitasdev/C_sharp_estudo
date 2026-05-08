
namespace relatorio2
{
    public class SystemClass
    {
        public void CaseSensitiveCase()
        {
            int aluno = 10;
            int Aluno = 20;
            Console.WriteLine($"aluno: {aluno}");
            Console.WriteLine($"Aluno: {Aluno}");
        }
        public void GradeClassifier(int nota)
        {
        
            if (nota < 50)
            {
                Console.WriteLine("Desempenho ruim");
            }
            else if (nota < 70)
            {
                Console.WriteLine("Desempenho mediano");
            }
            else if (nota < 90)
            {
                Console.WriteLine("Desempenho bom");
            }
            else
            {
                Console.WriteLine("Desempenho sensacional");
            }
        }
        public void SwitchCommand(char comando)
        {
            //Expressão switch, guardando resultado em variável
            /*
            string mensagem = comando switch
            {
                'A' => "Comando A",
                'B' => "Comando B",
                'C' => "Comando C",
                _ => "Comando desconhecido"
            };
            Console.WriteLine(mensagem); 
            */
            switch (comando)
            {
                case 'A':
                    Console.WriteLine("Comando A");
                    break;
                case 'B':
                    Console.WriteLine("Comando B");
                    break;
                case 'C':
                    Console.WriteLine("Comando C");
                    break;
                default:
                    Console.WriteLine("Comando desconhecido");
                    break;

            }
            
        }
        public void Count(int value)
        {
            Console.WriteLine($"\nContar até {value}");
            for (var i = 1; i <= value; i += 1)
            {
                Console.WriteLine(i);
            }
        }
        public void RegressiveCount(int contador)
        {
            Console.WriteLine("\nContagem regressiva:");
            while (contador >= 1)
            {
                Console.WriteLine(contador);
                contador -= 1;
            }
            Console.WriteLine("Contagem encerrada.");
        }
    }
}
