using System;

namespace ListaArtilheiros
{
    class Program
    {
        static ArtilheiroRepositorio repositorio = new ArtilheiroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarArtilheiros();
                        break;
                    case "2":
                        InserirArtilheiro();
                        break;
                    case "3":
                        AtualizaArtilheiro();
                        break;
                    case "4":
                        ExcluirArtilheiro();
                        break;
                    case "5":
                        VisualizarArtilheiro();
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
        private static void ExcluirArtilheiro()
        {
            Console.WriteLine("Digite o id do Artilheiro: ");
            int indiceArtilheiro = int.Parse(Console.ReadLine());
            
            repositorio.Exclui(indiceArtilheiro);
        }
        private static void VisualizarArtilheiro()
        {
            Console.WriteLine("Digite o id do Artilheiro: ");
            int indiceArtilheiro = int.Parse(Console.ReadLine());
            
            var artilheiro = repositorio.RetornaPorId(indiceArtilheiro);

            Console.WriteLine(artilheiro);
        }
        private static void AtualizaArtilheiro()
        {
            Console.WriteLine("Digite o id do Artilheiro: ");
            int indiceArtilheiro = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Time)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Time),i));
            }
            Console.WriteLine("Digite o time entre as opções acima: ");
            int entradaTime = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do artilheiro: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o ano da artilharia: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número de gols: ");
            int entradaGols = int.Parse(Console.ReadLine());


            Artilheiro atualizaArtilheiro = new Artilheiro(
                id: indiceArtilheiro,
                time: (Time)entradaTime,
                nome: entradaNome,
                ano: entradaAno,
                gols: entradaGols
            );

            repositorio.Atualiza(indiceArtilheiro,atualizaArtilheiro);
        }
        
        private static void ListarArtilheiros()
        {
            Console.WriteLine("Listar Artilheiros");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum Artilheiro cadastrado.");
                return;
            }

            foreach (var artilheiro in lista)
            {
                var excluido = artilheiro.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", artilheiro.retornaId(),artilheiro.retornaNome(), (excluido ? "** Excluido **" : ""));
            }
        }
        private static void InserirArtilheiro()
        {
            Console.WriteLine("Inserir novo artilheiro");
            foreach (int i in Enum.GetValues(typeof(Time)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Time),i));
            }
            Console.WriteLine("Digite o time entre as opções acima: ");
            int entradaTime = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do artilheiro: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite o ano: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número de gols");
            int entradaGols = int.Parse(Console.ReadLine());

            Artilheiro novoArtilheiro = new Artilheiro(
                id: repositorio.proximoId(),
                time: (Time)entradaTime,
                nome: entradaNome,
                ano: entradaAno,
                gols: entradaGols
            );
            repositorio.Insere(novoArtilheiro);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Informações sobre Brasileirão a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Artilheiros");
            Console.WriteLine("2- Incluir novo Artilheiro");
            Console.WriteLine("3- Atualizar Artilheiro");
            Console.WriteLine("4- Excluir Artilheiro");
            Console.WriteLine("5- Visualizar Artilheiro");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
