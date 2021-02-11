using System;
using System.Collections.Generic;

namespace Series
{
    class Program
    {
        private static SerieRepositorio db = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo!");
            Hub();
        }

        private static void Listar()
        {
            Console.WriteLine("Séries -----------------------------------------");
            List<Serie> series = db.Listar();
            foreach (var serie in series)
            {
                if (!serie.Excluido())
                {
                    Console.WriteLine($"({serie.GetId()+1}) {serie.GetTitulo()}");
                }
        }
            Console.WriteLine("------------------------------------------------");
        }

        private static Serie Cadastrar(int? editId)
        {
            int id = editId != null ? editId.GetValueOrDefault() : db.ProximoId();
            
            Console.Write("Título da série: ");
            string titulo = Console.ReadLine();
            
            Console.Write("Descrição da série: ");
            string descricao = Console.ReadLine();
            
            Console.WriteLine("Gênero da série: ");
            int i = 1;
            foreach (var gen in Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"\t{i++} - {gen}");
            int genero = Int32.Parse(Console.ReadLine());
            
            Console.Write("Ano da série: ");
            int ano = Int32.Parse(Console.ReadLine());
            
            return new Serie(id, (Genero) genero, titulo, descricao, ano);
        }
        
        private static void Hub()
        {
            string opcao = Menu();

            while (!opcao.Equals("X"))
            {
                switch (opcao)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Listar();
                        
                        Console.Write("Insira o id da série: ");
                        int id = Int32.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine();
                        Console.WriteLine(db.Recuperar(id));
                        break;
                    case "3":
                        db.Inserir(Cadastrar(null));
                        break;
                    case "4":
                        Listar();
                        
                        Console.Write("Insira o id da série: ");
                        db.Atualizar(Cadastrar(Int32.Parse(Console.ReadLine())-1));
                        break;
                    case "5":
                        Listar();
                        
                        Console.Write("Insira o id da série: ");
                        db.Excluir(Int32.Parse(Console.ReadLine())-1);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("A opção fornecida não é válida.");
                        break;
                }
                
                opcao = Menu();
            }

            Console.WriteLine("Obrigado por usar este serviço!");
        }

        private static string Menu()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("\t1 - Listar séries");
            Console.WriteLine("\t2 - Exibir série");
            Console.WriteLine("\t3 - Cadastrar série");
            Console.WriteLine("\t4 - Atualizar série");
            Console.WriteLine("\t5 - Excluir série");
            Console.WriteLine("\tC - Limpar tela");
            Console.WriteLine("\tX - Sair");

            return Console.ReadLine().ToUpper();
        }
    }
}
