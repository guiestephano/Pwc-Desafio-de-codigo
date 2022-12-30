using System;
using System.Collections.Generic;

namespace SeparadorDeEndereco
{
    class Program
    {
        static void Main(string[] args)
        {
            string endereco;
            List<Endereco> lista = new List<Endereco>();

            Console.Write("Digite quantos endereços irá adcionar: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Digite o {i}° endereço: ");
                endereco = Console.ReadLine();
                lista.Add(new Endereco(endereco));
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Endereços adicionados:");

            foreach (Endereco e in lista)
            {
                Console.WriteLine(e);
            }

             /*
             * Intanciação automatica dos edereços.
             *
            Endereco obj1 = new Endereco("Quirino, dos Santos 23 b");
            Endereco obj2 = new Endereco("4, Rue de la République");
            Endereco obj3 = new Endereco("100 Broadway Av");
            Endereco obj4 = new Endereco("Calle Sagasta, 26");
            Endereco obj5 = new Endereco("Calle 44 No 1991");
            Endereco obj6 = new Endereco("Rio Branco 23");
            Endereco obj7 = new Endereco("Cambuí 804B");
            Endereco obj8 = new Endereco("Babaçu 500");
            Endereco obj9 = new Endereco("Miritiba 339");

            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(obj3);
            Console.WriteLine(obj4);
            Console.WriteLine(obj5);
            Console.WriteLine(obj6);
            Console.WriteLine(obj7);
            Console.WriteLine(obj8);
            Console.WriteLine(obj9);
            */
        }

    }
}