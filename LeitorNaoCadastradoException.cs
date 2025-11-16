using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Alerta a Biblioteca que o Leitor não está cadastrado no sistema.
    /// </summary>
    public class LeitorNaoCadastradoException : Exception
    {
        public LeitorNaoCadastradoException()
        {

        }

        public LeitorNaoCadastradoException(string message) : base(message)
        {

        }
    }
}
