using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace _01ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("treinamento");
            IMongoCollection<Usuario> collectionUsuarios = database.GetCollection<Usuario>("usuarios");

            while (true)
            {
                int opcaoSelecionada = 0;
                bool opcaoSelecionadaEhValido = false;
                opcoes();
                opcaoSelecionadaEhValido = Int32.TryParse(Console.ReadLine(), out opcaoSelecionada);

                if (opcaoSelecionada == 1)
                {
                    opcaoInserir();
                }
                else if (opcaoSelecionada == 2)
                {
                    opcaoConsultar();
                }
                else if (opcaoSelecionada == 3)
                {
                    opcaoAlterar();
                }
                else if (opcaoSelecionada == 4)
                {
                    opcaoExcluir();
                }
            }

            void escreverLinha()
            {
                Console.WriteLine("-----------------------------------------------------------");
            }

            void opcoes()
            {
                Console.Clear();
                escreverLinha();
                Console.WriteLine("| 1 - Inserir | 2 - Consultar | 3 - Alterar | 4 - Excluir |");
                escreverLinha();
            }

            void opcaoInserir()
            {
                bool continuarExecucao = true;
                string respostaUsuario = string.Empty;

                while (continuarExecucao)
                {
                    Usuario usuario = new Usuario();
                    Console.Clear();
                    escreverLinha();
                    Console.WriteLine("|\t\t Opção selecionada | 1 - Inserir \t  |");
                    Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                    escreverLinha();
                    Console.WriteLine();

                    Console.WriteLine("Nome ");
                    usuario.Nome = Console.ReadLine();

                    Console.WriteLine("Email ");
                    usuario.Email = Console.ReadLine();

                    collectionUsuarios.InsertOne(usuario);

                    Console.WriteLine();
                    Console.WriteLine("Inserir novo usuário? (S ou N)");
                    respostaUsuario = Console.ReadLine();

                    if (respostaUsuario.Equals("S") | respostaUsuario.Equals("s"))
                    {
                        continuarExecucao = true;
                        Console.Clear();
                    }
                    else
                    {
                        continuarExecucao = false;
                        Console.Clear();
                    }
                }
            }

            void opcaoConsultar()
            {
                string nomeBusca = string.Empty;
                int quantidadeUsuarios = 0;
                Console.Clear();
                escreverLinha();
                Console.WriteLine("|\t\t Opção selecionada | 2 - Consultar \t  |");
                Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                escreverLinha();
                Console.WriteLine();
                Console.WriteLine("Digite o nome para pesquisar");
                nomeBusca = Console.ReadLine();
                Expression<Func<Usuario, bool>> filter = x => x.Nome.Contains(nomeBusca);
                IList<Usuario> usuariosLista = collectionUsuarios.Find(filter).ToList();
                quantidadeUsuarios = usuariosLista.Count;

                foreach (var usuario in usuariosLista)
                {
                    Console.WriteLine("ID:\t" + usuario.ID);
                    Console.WriteLine("Nome:\t" + usuario.Nome);
                    Console.WriteLine("Email:\t" + usuario.Email);
                    Console.WriteLine();
                }

                Console.WriteLine();
                escreverLinha();
                Console.WriteLine("Total de usuários encontrados " + quantidadeUsuarios);
                Console.ReadLine();
            }

            void opcaoAlterar()
            {
                Console.Clear();
                escreverLinha();
                Console.WriteLine("|\t\t Opção selecionada | 3 - Alterar \t  |");
                Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                escreverLinha();
            }

            void opcaoExcluir()
            {
                Console.Clear();
                escreverLinha();
                Console.WriteLine("|\t\t Opção selecionada | 4 - Excluir \t  |");
                Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                escreverLinha();
            }
        }
    }
}
