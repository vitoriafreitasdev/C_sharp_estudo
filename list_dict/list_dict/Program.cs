using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Timers;
using System;
using System.Collections.Generic;

List<int> numeros = new List<int>();
numeros.Add(5);
numeros.Add(10);
numeros.Add(15);

foreach (int n in numeros)
{
    Console.WriteLine(n);
}

Dictionary<string, int> idades = new Dictionary<string, int>();
idades["Alice"] = 30;
idades["Bob"] = 25;

foreach (KeyValuePair<string, int> par in idades)
{
    Console.WriteLine($"{ par.Key}: { par.Value}");
}

foreach(string chave in idades.Keys) {
    Console.WriteLine(chave);
}

foreach (int valor in idades.Values)
{
    Console.WriteLine(valor);
}


///////

namespace ExemploListEDictionary
{
    
    internal class Program
    {
        public IEnumerable<int> NumerosImpares(int n)
        {
            for (int i = 1; i <= n; i += 2)
                yield return i;
        }

        static void Main(string[] args)
        {
            // Cria uma lista de produtos (List<Produto>)
            List<Produto> catalogo = new List<Produto>
            {
                new Produto(1, "Teclado mecânico", 350.00m),
                new Produto(2, "Mouse gamer", 150.00m),
                new Produto(3, "Monitor 24\"", 900.00m),
                new Produto(4, "Headset", 250.00m)
            };

            Console.WriteLine("=== Catálogo inicial (List<Produto>) ===");
            ExibirCatalogo(catalogo);
            Console.WriteLine();
            Console.WriteLine($"Count da lista: {catalogo.Count}");
            Console.WriteLine($"Capacity da lista: {catalogo.Capacity}");

            // Adiciona mais um produto: a lista cresce conforme necessário
            catalogo.Add(new Produto(5, "Webcam Full HD", 300.00m));

            Console.WriteLine();
            Console.WriteLine("=== Catálogo após adicionar um produto ===");
            ExibirCatalogo(catalogo);
            Console.WriteLine();
            Console.WriteLine($"Count da lista: {catalogo.Count}");
            Console.WriteLine($"Capacity da lista: {catalogo.Capacity}");

            // Cria um Dictionary<int, Produto> para acesso rápido por Id
            Dictionary<int, Produto> produtosPorId = new Dictionary<int, Produto>();

            foreach (var produto in catalogo)
            {
                produtosPorId[produto.Id] = produto;
            }

            Console.WriteLine();
            Console.Write("Digite um id de produto para buscar: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int idBuscado))
            {
                // Busca segura com TryGetValue (evita exceção se a chave não existir)
                if (produtosPorId.TryGetValue(idBuscado, out Produto produtoEncontrado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Produto encontrado no Dictionary:");
                    Console.WriteLine(produtoEncontrado);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Nenhum produto encontrado com esse id.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Id inválido.");
            }

            Console.WriteLine();
            Console.WriteLine("=== Produtos com preço a partir de R$ 300,00 ===");

            // Usa um método que devolve IEnumerable<Produto> com yield return
            foreach (var produto in FiltrarPorPrecoMinimo(catalogo, 300.00m))
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para sair.");
            Console.ReadLine();
        }

        // Este método aceita IEnumerable<Produto>, não apenas List<Produto>
        // Qualquer coleção genérica que implemente IEnumerable<Produto> pode ser passada aqui
        static void ExibirCatalogo(IEnumerable<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        // Exemplo de iterator que devolve apenas produtos acima de um preço mínimo
        // O retorno é IEnumerable<Produto>, implementado com yield return
        static IEnumerable<Produto> FiltrarPorPrecoMinimo(
            IEnumerable<Produto> produtos,
            decimal precoMinimo)
        {
            foreach (var produto in produtos)
            {
                if (produto.Preco >= precoMinimo)
                {
                    yield return produto;
                }
            }
        }
    }

    internal class Produto
    {
        public int Id { get; }
        public string Nome { get; }
        public decimal Preco { get; }

        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} (R$ {Preco:F2})";
        }
    }
}