using System;

namespace Animes
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                     ListarAnimes();
                     break;
                   case "2":
                     InserirAnime();
                     break; 
                   case "3":
                      AtualizarAnime();
                      break;
                   case "4":
                      ExcluirAnime();
                      break;
                   case "5":
                      VisualizarAnime();
                      break;
                   case "C":
                      Console.Clear();
                      break;

                   default:
                      throw new ArgumentOutOfRangeException();       
                }

              opcaoUsuario = ObterOpcaoUsuario();
            }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
       }

       private static void ExcluirAnime()
       {
           Console.Write("Digite o id do Anime: ");
           int indiceAnime = int.Parse(Console.ReadLine());

           repositorio.Exclui(indiceAnime);
       }

       private static void VisualizarAnime()
       {
           Console.Write("Digite o id do Anime: ");
           int indiceAnime = int.Parse(Console.ReadLine());

           var anime = repositorio.RetornaPorID(indiceAnime);

           Console.WriteLine(anime);
       }
        
       private static void AtualizarAnime()
       {
           Console.Write("Digite o id do anime: ");
           int indiceAnime = int.Parse(Console.ReadLine());

           foreach(int i in Enum.GetValues(typeof(Categoria)))
           {
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
           }
           Console.Write("Digite a categoria entre as opções acima: ");
           int entradaCategoria = int.Parse(Console.ReadLine());

           Console.Write("Digite o Título do Anime: ");
           string entradaTitulo = Console.ReadLine();

           Console.Write("Digite o Ano de Lançamento do Anime: ");
           int entradaAno = int.Parse(Console.ReadLine());

           Console.Write("Digite a Descrição do Anime: ");
           string entradaDescricao = Console.ReadLine();

           Anime atualizaAnime = new Anime(id: indiceAnime,
                                       categoria: (Categoria)entradaCategoria,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);

           repositorio.Atualiza(indiceAnime, atualizaAnime);                            
           
       }
        
        private static void ListarAnimes()
        {
            Console.WriteLine("Listar animes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrado.");
                return;
            }
            foreach (var anime in lista)
            {
                var excluido = anime.retornaExcluido();
            
                Console.WriteLine("#ID {0}: - {1}  {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        
        private static void InserirAnime()
        {
            Console.WriteLine("Insira um novo anime");

            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("Digite uma categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorio.ProximoId(),
                                       categoria: (Categoria)entradaCategoria,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);

            repositorio.Insere(novoAnime);                        
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("------------");
            Console.WriteLine("ANIME DAITAN");
            Console.WriteLine("------------");
            Console.WriteLine("Seja muito bem vindo!!");

            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Listar animes");
            Console.WriteLine("2- Inserir um novo anime");
            Console.WriteLine("3- Atualizar anime");
            Console.WriteLine("4- Excluir anime");
            Console.WriteLine("5- Visualizar anime");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
