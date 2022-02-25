using System;
using Biblioteca.Classes;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    class Menu
    {
        public static void OpcoesMenu()
        {
            Amigo amigo = new Amigo();
            
            var listaDosAmigos = ManipularArquivo.LerArquivo();

            CalcularAniversario.MostrarAniversariantesHoje(listaDosAmigos);

            while (true)
            {
                Cabecalho("Opções Menu");
                Console.WriteLine("1 - Cadastrar Aniversário" +
                    "\n2 - Apagar Aniversariante" +
                    "\n3 - Atualizar Aniversário" +
                    "\n4 - Buscar Aniversariante" +
                    "\n0 - Sair do Programa");

                int escolhaMenu = int.Parse(Console.ReadLine());

                if (escolhaMenu == 1)
                {
                    Cabecalho("Cadastrar Aniversário");
                    amigo.AdicionarPessoa(listaDosAmigos);
                }
                else if (escolhaMenu == 2)
                {
                    Cabecalho("Apagar Aniversariante");
                    amigo.ApagarPessoa(listaDosAmigos);
                }
                else if (escolhaMenu == 3)
                {
                    Cabecalho("Atualizar Aniversário");
                    amigo.AtualizarPessoa(listaDosAmigos);
                }
                else if (escolhaMenu == 4)
                {
                    Cabecalho("Buscar Aniversariante");
                    amigo.BuscarPessoa(listaDosAmigos);
                }
                else if (escolhaMenu == 0)
                {
                    Cabecalho("Sair do Programa");
                    break;
                }
                else
                {
                    Cabecalho("Opção Inválida");
                }
            }
        }

        private static void Cabecalho(string textoCabecalho)
        {
            Console.WriteLine("\n===============" + textoCabecalho + "===============\n");
        }
    }
}
