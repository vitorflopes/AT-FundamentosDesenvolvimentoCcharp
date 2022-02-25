using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Classes
{
    interface IPessoa
    {
        void AdicionarPessoa(List<Amigo> listaBase);
        void ApagarPessoa(List<Amigo> listaBase);
        void AtualizarPessoa(List<Amigo> listaBase);
        void BuscarPessoa(List<Amigo> listaBase);
    }
}
