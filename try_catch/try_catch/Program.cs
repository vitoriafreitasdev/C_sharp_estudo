using static System.Runtime.InteropServices.JavaScript.JSType;

try
{

    // Código que pode lançar exceções
    int Numerador = 10;
    int Denominador = 5;
    int resultado = Numerador / Denominador;
    //Arquivo.Write("Salvando dados...");
}
catch (DivideByZeroException ex)
{
    // Tratamento específico de divisão por zero
    Console.WriteLine($"Erro de divisão: { ex.Message}");
}
catch (IOException ex)
{
    // Tratamento de erros de I/O
    Console.WriteLine($"Erro de I / O: { ex.Message}");
}
catch (Exception ex)
{
    // Tratamento genérico de outras exceções
    Console.WriteLine($"Erro inesperado: { ex.Message}");
}
finally
{
    // Código sempre executado (por exemplo, liberar recursos)
    Console.WriteLine("Operação finalizada.");
}