using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Alerta que a Bilioteca que possivelmente a Publicação em questão não existe no acervo.
    /// </summary>
    public class LivroNaoEncontradoException : Exception
    {
        public LivroNaoEncontradoException()
        {

        }

        public LivroNaoEncontradoException(string message) : base(message)
        {

        }
    }
}
