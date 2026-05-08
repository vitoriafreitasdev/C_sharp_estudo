using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace relatorio3
{
    public class Aluno
    {
        private string _nomeAluno;
        private int _matricula;
        private string _turma;


        public string NomeAluno
        {
            get
            {
                return _nomeAluno;
            }


            set
            {
                _nomeAluno = value;
            }
        }
        public int Matricula
        {
            get
            {
                return _matricula;
            }


            set
            {
                _matricula = value;
            }
        }
        public string Turma
        {
            get
            {
                return _turma;
            }


            set
            {
                _turma = value;
            }
        }

        public void MostrarAtributos()
        {
            Console.WriteLine(_nomeAluno);
        }
    }
}