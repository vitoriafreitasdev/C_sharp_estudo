
namespace relatorio3
{

    class Program
    {
        static void Main(string[] args)
        {
            // Criação do jogo
            Jogo jogo = new Jogo();
            // Execução do jogo
            //jogo.Execucar();

            Aluno aluno = new Aluno();

            string nome = "Paulo";
            aluno.NomeAluno = nome;
            aluno.MostrarAtributos();
        }
    }

}

