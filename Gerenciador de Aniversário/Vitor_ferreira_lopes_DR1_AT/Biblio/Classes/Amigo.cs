using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Classes
{
    public class Amigo : IPessoa
    {
        public string Nome;
        public string Sobrenome;
        public DateTime Aniversario;

        public Amigo(string nome, string sobrenome, DateTime aniversario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Aniversario = aniversario;
        }

        public Amigo() { }

        public void AdicionarPessoa(List<Amigo> listaBase)
        {
            Console.WriteLine("Digite o nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o sobrenome:");
            string sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            DateTime nascimento = DateTime.Parse(Console.ReadLine());

            Amigo novoAmigo = new Amigo(nome, sobrenome, nascimento);
            listaBase.Add(novoAmigo);

            ManipularArquivo.GravarArquivo(listaBase);
            Console.WriteLine("Amigo gravado com sucesso!");
        }

        public void ApagarPessoa(List<Amigo> listaBase)
        {
            ListarAmigos(listaBase);

            if (listaBase.Count == 0)
            {
                Console.WriteLine("Não existe nenhum amigo no cadastro, adicione amigos para conseguir apagar!");
            }
            else
            {
                Console.WriteLine("\nEscolha qual pessoa deseja apagar:");
                int opcaoApagar = int.Parse(Console.ReadLine());

                listaBase.RemoveAt(opcaoApagar);

                ManipularArquivo.GravarArquivo(listaBase);
                Console.WriteLine("Amigo apagado com sucesso!");
            }
        }

        public void AtualizarPessoa(List<Amigo> listaBase)
        {
            ListarAmigos(listaBase);

            if (listaBase.Count == 0)
            {
                Console.WriteLine("Não existe nenhum amigo no cadastro, adicione amigos para conseguir atualizar!");
            }
            else
            {
                Console.WriteLine("\nEscolha qual pessoa deseja mudar a data de nascimento:");
                int opcaoApagar = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a nova data de nascimento:");
                DateTime novaData = DateTime.Parse(Console.ReadLine());

                listaBase[opcaoApagar].Aniversario = novaData;

                ManipularArquivo.GravarArquivo(listaBase);
                Console.WriteLine("Aniversário atualizado com sucesso!");
            }
        }

        public void BuscarPessoa(List<Amigo> listaBase)
        {
            if (listaBase.Count == 0)
            {
                Console.WriteLine("Não existe nenhum amigo no cadastro, adicione amigos para conseguir buscar!");
            }
            else
            {
                List<Amigo> listaBaseAuxiliar = new List<Amigo>();
                int count = 0;

                Console.WriteLine("Digite o nome que deseja procurar:");
                string procurarNome = Console.ReadLine();

                foreach (var amigo in listaBase)
                {
                    string nomeCompleto = amigo.Nome + " " + amigo.Sobrenome;
                    if (nomeCompleto.Contains(procurarNome))
                    {
                        listaBaseAuxiliar.Add(amigo);
                    }
                }
                if (listaBaseAuxiliar.Count == 0)
                {
                    Console.WriteLine("Não existe nenhum nome com a seguinte palavra chave: " + procurarNome);
                }
                else
                {
                    Console.WriteLine("\nSelecione uma das opções abaixo para visualizar os dados da pessoa:\n");

                    foreach (var t in listaBaseAuxiliar)
                    {
                        Console.WriteLine($"[{count++}] - " + t.Nome + " " + t.Sobrenome);
                    }

                    int amigoEscolhido = int.Parse(Console.ReadLine());

                    Console.WriteLine(listaBaseAuxiliar[amigoEscolhido].Nome + " " + listaBaseAuxiliar[amigoEscolhido].Sobrenome + " " + listaBaseAuxiliar[amigoEscolhido].Aniversario);
                    Console.WriteLine("O tempo que falta para o próximo aniversário é: " + CalcularAniversario.CalcularProximoAniversario(listaBaseAuxiliar[amigoEscolhido].Aniversario) + " dias.");
                }
            }
        }

        private static void ListarAmigos(List<Amigo> listaBase)
        {
            int count = 0;
            foreach (var amigos in listaBase)
            {
                Console.WriteLine(count + " - " + amigos.Nome + " " + amigos.Sobrenome + " " + amigos.Aniversario);
                count++;
            }
        }
    }
}
