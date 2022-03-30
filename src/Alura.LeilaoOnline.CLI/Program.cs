using System;

namespace Alura.LeilaoOnline.CLI
{
    class Program
    {
        private static void MostrarComandos()
        {
            Console.WriteLine("\nComandos disponíveis\n");
            Console.WriteLine("  listar - lista os leilões cadastrados");
            Console.WriteLine("  detalhe <Id do Leilão> - mostra os detalhes do leilão identificado por <Id do Leilão>");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("leilao-adm - v1.0");
            Console.WriteLine("=================");
            Console.WriteLine("Interface de linha de comando para administração de leilões");

            if (args.Length == 0)
            {
                MostrarComandos();
                return;
            } else if (args[0] == "listar")
            {
                // listar leilões
                

            } else if (args[0] == "detalhe")
            {
                // detalhe do leilão

            }
        }
    }
}
