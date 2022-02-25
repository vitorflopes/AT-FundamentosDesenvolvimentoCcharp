using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Classes
{
    public class CalcularAniversario
    {
        public static int CalcularProximoAniversario(DateTime aniversario)
        {
            DateTime dataAtual = DateTime.Today;
            DateTime proximaData = aniversario.AddYears(dataAtual.Year - aniversario.Year);

            if (proximaData < dataAtual)
                proximaData = proximaData.AddYears(1);

            int numeroDias = (proximaData - dataAtual).Days;

            return numeroDias;
        }

        public static void MostrarAniversariantesHoje(List<Amigo> listaBase)
        {
            bool temNiverHoje = false;

            foreach (var amigo in listaBase)
            {
                if (amigo.Aniversario.Day == DateTime.Today.Day && amigo.Aniversario.Month == DateTime.Today.Month)
                {
                    Console.WriteLine(amigo.Nome + " " + amigo.Sobrenome);
                    temNiverHoje = true;
                }
            }
            if (temNiverHoje)
            {
                Console.WriteLine("Parabéns, hoje é seu aniversário!");
            }
        }
    }
}
