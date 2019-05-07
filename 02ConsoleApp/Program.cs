using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
                else if(opcaoSelecionada == 2)
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

                Console.ReadLine();
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
                Console.Clear();
                escreverLinha();
                Console.WriteLine("|\t\t Opção selecionada | 1 - Inserir \t  |");
                Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                escreverLinha();                
            }

            void opcaoConsultar()
            {
                Console.Clear();
                escreverLinha();
                Console.WriteLine("|\t\t Opção selecionada | 2 - Consultar \t  |");
                Console.WriteLine("|\t\t\t 0 - Voltar \t\t\t  |");
                escreverLinha();                
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
