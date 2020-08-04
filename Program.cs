using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Text Editor");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Editar arquivo");
            Console.WriteLine("0 - Sair");

            Console.Write("\nInforme a opção desejada: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.Write("Caminho do arquivo: ");
            string path = Console.ReadLine(); 

            using (StreamReader file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine();
                Console.WriteLine(text);
                Menu(); 
            }
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite o texto no campo abaixo (ESC para sair)");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
            Menu();

        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.Write("Informe o path para salvamento: ");
            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");

        }
    }
}
