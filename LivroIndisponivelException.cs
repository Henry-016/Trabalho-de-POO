using System;

namespace ProjetinDePOO.Excecoes
{
    public class LivroIndisponivelException : Exception
    {
        /// <summary>
        /// Alerta que a Publicação em questão não está disponível pra uso.
        /// </summary>
        public LivroIndisponivelException()
        {

        }

        public LivroIndisponivelException(string message) : base(message)
        {

        }
    }
}
