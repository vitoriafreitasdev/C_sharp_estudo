
namespace relatorio3
{

    class Program
    {
        static void Main(string[] args)
        {
            // Inicialização do jogo
            Game jogo = new Game();
            jogo.Execucar();
            Aluno aluno = new Aluno();
            string n = "Ana";
            aluno.NomeAluno = n;
            aluno.atributos();
        }
    }

}

