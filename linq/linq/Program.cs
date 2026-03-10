using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DemoLinqIntro
{
    internal static class Program
    {
        private static void Main()
        {
            // Lambda que calcula o quadrado de um inteiro
            Func<int, int> quadrado = x => x * x;

            Console.Write("Informe um número inteiro:" );
            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }
            int resultado = quadrado(valor);
            Console.WriteLine($"O quadrado de { valor} é { resultado}.");
            Console.WriteLine("Pressione ENTER para sair.");
            Console.ReadLine();
            ////////////
            List<int> numeros = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
            // Sintaxe de consulta
            IEnumerable<int> consulta =
            from n in numeros
            where n % 2 == 0
            orderby n descending
            select n * n;
            Console.WriteLine("Resultados da consulta LINQ:");
            foreach (int val in consulta)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("Pressione ENTER para sair.");
            Console.ReadLine();

            List<int> numeros2 = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
            IEnumerable<int> consulta2 = numeros2
            .Where(n => n % 2 == 0) // Lambda como predicado
            .OrderByDescending(n => n) // Lambda como chave de ordenação
            .Select(n => n * n); // Lambda como projeção
            Console.WriteLine("Resultados da consulta LINQ com lambdas:");
            foreach (int val in consulta)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("Pressione ENTER para sair.");
            Console.ReadLine();

            int[] nums = { 1, 2, 3, 4, 5, 6 };
            var pares = nums.Where(n => n % 2 == 0);
            foreach (var p in pares)
                Console.WriteLine(p);
            // Saída esperada: 2 4 6

            string[] nomes = { "ana", "beatriz", "carlos" };
            var maiusculos = nomes.Select(n => n.ToUpper());
            foreach (var m in maiusculos)
                Console.WriteLine(m);
            // Saída esperada: ANA, BEATRIZ, CARLOS

            string[] ns = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            var query = ns
             .Where(ns => ns.Contains("a"))
             .Select(ns => ns.ToUpper());
            foreach (var nome in query)
                Console.Write(nome + "");
            // Exemplo de saída: “HARRY MARY JAY”


            int[] num = { 1, 2, 3, 4, 5, 6 };
            var grupos = num.GroupBy(n => (n % 2 == 0) ? "Par" : "Ímpar");
            foreach (var grupo in grupos)
            {
                Console.WriteLine("Grupo:  "+grupo.Key);
                foreach (var g in grupo)
                    Console.WriteLine(" " +g);
            }
            // Saída esperada:
            // Grupo: Ímpar
            // 1
            // 3
            // 5
            // Grupo: Par
            // 2
            // 4
            // 6
        }
    }
}