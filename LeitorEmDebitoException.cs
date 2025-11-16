using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Alerta a Biblioteca o Leitor em questão possui dívida com ela.
    /// </summary>
    public class LeitorEmDebitoException : Exception
    {
        public LeitorEmDebitoException()
        {

        }

        public LeitorEmDebitoException(string message) : base(message)
        {

        }
    }
}
