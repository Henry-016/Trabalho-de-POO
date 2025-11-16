using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Alerta a Biblioteca que já existe uma Publicação com o mesmo código no Acervo.
    /// </summary>
    public class LivroJaExistenteException : Exception
    {
        public LivroJaExistenteException()
        {

        }

        public LivroJaExistenteException(string message) : base(message)
        {

        }
    }
}
