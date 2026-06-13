using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace relatorio3
{
    public class Aluno
    {
        private string _nome;
        private int _matricula;
        private string _turma;


        public string NomeAluno
        {
            get
            {
                return _nome;
            }


            set
            {
                _nome = value;
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

        public void atributos()
        {
            Console.WriteLine(_nome);
        }
    }
}