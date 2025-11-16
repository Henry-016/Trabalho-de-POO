using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Alerta a Biblioteca que o Leitor com o CPF em questão já está cadastrado no sistema.
    /// </summary>
    public class LeitorJaCadastradoException : Exception
    {

        public LeitorJaCadastradoException()
        {

        }

        public LeitorJaCadastradoException(string message) : base(message)
        {

        }
    }
}
