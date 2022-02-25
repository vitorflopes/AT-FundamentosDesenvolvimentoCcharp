using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca.Classes
{
    public class ManipularArquivo
    {
        public static List<Amigo> LerArquivo()
        {
            using (var fluxoLeitura = new StreamReader("Lista Amigos.txt"))
            {
                List<Amigo> listAmigos = new List<Amigo>();
                var arrayAmigos = fluxoLeitura.ReadToEnd();

                string[] array = arrayAmigos.Split('\n');

                for (int i = 0; i < array.Length - 1; i++)
                {
                    Amigo a = new Amigo();

                    string[] arrayAuxiliar = array[i].Split(';');

                    a.Nome = arrayAuxiliar[0];
                    a.Sobrenome = arrayAuxiliar[1];
                    a.Aniversario = Convert.ToDateTime(arrayAuxiliar[2]);

                    listAmigos.Add(a);
                }

                return listAmigos;
            }
        }

        public static void GravarArquivo(List<Amigo> NovaListAmigos)
        {
            using (var fluxoEscrita = new StreamWriter("Lista Amigos.txt"))
            {
                for (var i = 0; i <= NovaListAmigos.Count - 1; i++)
                {
                    fluxoEscrita.WriteLine(NovaListAmigos[i].Nome + ";" + NovaListAmigos[i].Sobrenome + ";" + Convert.ToString(NovaListAmigos[i].Aniversario));
                }
            }
        }
    }
}
