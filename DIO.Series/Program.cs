using DIO.Series.Classes;
using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            char op = PrintMenu();
            while (op != 'X')
            {
                switch (op)
                {
                    case '1':
                        ListarSeries();
                        break;
                    case '2':
                        InserirSerie();
                        break;
                    case '3':
                        AtualizarSerie();
                        break;
                    case '4':
                        ExcluirSerie();
                        break;
                    case '5':
                        VisualizarSerie();
                        break;
                    default:
                        break;
                }
                op = PrintMenu();
            }
            ClearScreen();
            Console.WriteLine("\n\n\n\n");
            TextCenter("OBRIGADO POR CONSULTAR NOSSAS SÉRIES");
            Console.WriteLine("\n\n");
            TextCenter("Estaremos aguardando seu retorno");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("VISUALIZANDO SÉRIE\n\n");

            TextCenter("Digite o Id da Série: ", 60);
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine(repositorio.RetornaPorId(id));
            Confirmacao("exibida");
        }

        private static void ExcluirSerie()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("EXCLUINDO SÉRIE\n\n");

            TextCenter("Digite o Id da Série: ", 60);
            int.TryParse(Console.ReadLine(), out int id);
            repositorio.Excluir(id);
            Confirmacao("excluída");
        }

        private static void AtualizarSerie()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("ATUALIZANDO SÉRIE\n\n");

            TextCenter("Digite o Id da Série: ", 60);
            int.TryParse(Console.ReadLine(), out int id);
            repositorio.Atualiza(id, GetSerie(id));
            Confirmacao("atualizada");
        }

        private static void InserirSerie()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("INSERINDO NOVA SÉRIE\n\n");
            repositorio.Insere(GetSerie(null));
            Confirmacao("inserida");
        }

        private static void ListarSeries()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("LISTANDO SÉREIS CADASTRADAS\n\n");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
                TextCenter("NENHUMA SÉRIE CADASTRADA");
            else
                foreach (var item in lista)
                    Console.WriteLine($"\t#{item.RetornaId()} - {item.RetornaTitulo()} - Ativo: {(item.RetornaAtivo() ? "Sim" : "Não")}");
            Console.ReadLine();
        }

        private static Serie GetSerie(int? id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                TextCenter($"{i} - {Enum.GetName(typeof(Genero), i)}\n", 60);
            }
            TextCenter("Digite o Número do Gênero: ", 60);
            int.TryParse(Console.ReadLine(), out int genero);
            TextCenter("Digite o Título da Série.: ", 60);
            string titulo = Console.ReadLine();
            TextCenter("Digite a Descrição.......: ", 60);
            string descricao = Console.ReadLine();
            TextCenter("Digite o Ano de Início...: ", 60);
            int.TryParse(Console.ReadLine(), out int ano);
            Serie serie = new Serie(id ?? repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);
            return serie;
        }

        private static char PrintMenu()
        {
            ClearScreen();
            TextCenter("DIO Séries a seu dispor!!!\n\n");
            TextCenter("1 - Lista Séries\n", 40);
            TextCenter("2 - Inserir Nova Série\n", 40);
            TextCenter("3 - Atualizar Série\n", 40);
            TextCenter("4 - Excluir Série\n", 40);
            TextCenter("5 - Visualizar Série\n", 40);
            TextCenter("X - Sair\n\n", 40);
            TextCenter("Informe a opção desejada: ", 40);
            return Console.ReadLine().ToUpper()[0];
        }

        private static void TextCenter(string texto)
        {
            int x = (Console.WindowWidth - texto.Length) / 2;
            for (int i = 0; i < x; i++)
                Console.Write(" ");
            Console.Write(texto);
        }

        private static void TextCenter(string texto, int tamanho)
        {
            int x = (Console.WindowWidth - tamanho) / 2;
            for (int i = 0; i < x; i++)
                Console.Write(" ");
            Console.Write(texto);
        }

        private static void ClearScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
        }

        private static void Confirmacao(string texto)
        {
            Console.Write("\n\n");
            TextCenter($"Série {texto} com Sucesso", 60);
            Console.Write("\n\n");
            TextCenter("Pressione ENTER para voltar", 60);
            Console.ReadLine();
        }
    }
}
