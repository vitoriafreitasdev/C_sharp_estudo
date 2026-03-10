

using System;
using System.Collections.Generic;

namespace GenericosDemo
{
    // Classe base usada como restrição de herança
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
    }

    // Tipo concreto que implementa igualdade e ordenação
    public class Cliente : EntidadeBase, IEquatable<Cliente>, IComparable<Cliente>
    {
        public string Nome { get; set; }

        // Igualdade fortemente tipada
        public bool Equals(Cliente other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Nome, other.Nome, StringComparison.Ordinal);
        }

        // Sobrescreve Equals(object) para ser consistente
        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        // GetHashCode consistente com Equals
        public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashNome = Nome == null ? 0 : Nome.GetHashCode();
            return hashId ^ hashNome;
        }

        // Ordenação natural por nome
        public int CompareTo(Cliente other)
        {
            if (other == null) return 1;
            return string.Compare(Nome, other.Nome, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{Id}: {Nome}";
        }
    }

    // Comparador externo para ordenar Cliente por Id
    public class ClientePorIdComparer : IComparer<Cliente>
    {
        public int Compare(Cliente x, Cliente y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.Id.CompareTo(y.Id);
        }
    }

    // Comparador de igualdade externo para comparar clientes pelo Nome
    public class ClientePorNomeIgualdade : IEqualityComparer<Cliente>
    {
        public bool Equals(Cliente x, Cliente y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return string.Equals(x.Nome, y.Nome, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Cliente obj)
        {
            return obj.Nome == null
                ? 0
                : obj.Nome.ToUpperInvariant().GetHashCode();
        }
    }

    // Classe genérica com restrição de herança e new()
    public class Repositorio<T> where T : EntidadeBase, new()
    {
        private readonly List<T> _itens = new List<T>();

        public void Adicionar(T item)
        {
            _itens.Add(item);
        }

        // Demonstra o uso de new() para criar instâncias de T
        public T CriarENovo()
        {
            var entidade = new T(); // Permitido por causa da restrição new()
            _itens.Add(entidade);
            return entidade;
        }

        public IEnumerable<T> Todos()
        {
            return _itens;
        }
    }

    public static class UtilitariosGenericos
    {
        // Método genérico que precisa de ordenação: T implementa IComparable<T>
        public static T EncontrarMaximo<T>(IEnumerable<T> itens) where T : IComparable<T>
        {
            bool primeiro = true;
            T maximo = default(T);

            foreach (var item in itens)
            {
                if (primeiro)
                {
                    maximo = item;
                    primeiro = false;
                }
                else if (item.CompareTo(maximo) > 0)
                {
                    maximo = item;
                }
            }

            if (primeiro)
                throw new InvalidOperationException("Sequência vazia.");

            return maximo;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Uso de Repositorio<T> com restrições: T deve ser EntidadeBase e ter new()
            var repositorio = new Repositorio<Cliente>();
            repositorio.Adicionar(new Cliente { Id = 2, Nome = "Maria" });
            repositorio.Adicionar(new Cliente { Id = 1, Nome = "João" });
            repositorio.Adicionar(new Cliente { Id = 3, Nome = "Ana" });

            // Criação de instância via new() dentro do genérico
            var clienteGerado = repositorio.CriarENovo();
            clienteGerado.Id = 4;
            clienteGerado.Nome = "Gerado com new()";

            Console.WriteLine("Clientes cadastrados no repositório (ordem de inserção):");
            foreach (var c in repositorio.Todos())
            {
                Console.WriteLine(c);
            }

            // Convertendo para List<Cliente> para usar Sort e Contains
            var clientes = new List<Cliente>(repositorio.Todos());

            // Ordenação natural por Nome usando IComparable<Cliente>
            clientes.Sort();
            Console.WriteLine();
            Console.WriteLine("Clientes ordenados por nome (IComparable<T>):");
            foreach (var c in clientes)
            {
                Console.WriteLine(c);
            }

            // Ordenação customizada por Id usando IComparer<Cliente> externo
            clientes.Sort(new ClientePorIdComparer());
            Console.WriteLine();
            Console.WriteLine("Clientes ordenados por Id (IComparer<T> externo):");
            foreach (var c in clientes)
            {
                Console.WriteLine(c);
            }

            // Uso de método genérico que exige IComparable<T>
            var maxPorNome = UtilitariosGenericos.EncontrarMaximo(clientes);
            Console.WriteLine();
            Console.WriteLine($"Maior cliente segundo CompareTo (nome): {maxPorNome}");

            // Uso de IEqualityComparer<T> externo em um HashSet<T>
            var conjuntoPorNome = new HashSet<Cliente>(new ClientePorNomeIgualdade());
            conjuntoPorNome.Add(new Cliente { Id = 10, Nome = "JOÃO" });
            conjuntoPorNome.Add(new Cliente { Id = 11, Nome = "joão" });

            Console.WriteLine();
            Console.WriteLine("Quantidade de clientes distintos em HashSet por nome (IEqualityComparer<T>):");
            Console.WriteLine(conjuntoPorNome.Count); // Deve ser 1, pois nomes equivalem ignorando maiúsculas/minúsculas

            // Uso de IEquatable<Cliente> em List<T>.Contains
            var procurado = new Cliente { Id = 2, Nome = "Maria" };
            bool contem = clientes.Contains(procurado);
            Console.WriteLine();
            Console.WriteLine($"Lista contém cliente igual a (Id=2, Nome=Maria)? {contem}");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para sair.");
            Console.ReadLine();
        }
    }
}