using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Verifica se Leitor tem empréstimos ativos.
    /// </summary>
    public class LeitorComLivrosEmPosse : Exception
    {
        public LeitorComLivrosEmPosse()
        {

        }

        public LeitorComLivrosEmPosse(string message) : base(message)
        {

        }
    }
}
