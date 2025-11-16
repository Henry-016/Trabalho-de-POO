using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Representa a Ausência de um Empréstimo.
    /// </summary>
    public class EmprestimoNaoRealizadoException : Exception
    {
        public EmprestimoNaoRealizadoException()
        {

        }

        public EmprestimoNaoRealizadoException(string message) : base(message)
        {

        }
    }
}
