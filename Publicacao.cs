using System;

namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa de forma genérica um Livro ou Monografia que pertence a Biblioteca.
    /// </summary>
    public abstract class Publicacao
    {
        /// <summary>
        /// Representa de forma genérica o Titulo da Publicação.
        /// </summary>
        public string Titulo { get; private set; }

        /// <summary>
        /// Representa de forma genérica o Ano que a Publicação foi lançada.
        /// </summary>
        public double AnoPublicacao { get; private set; }

        /// <summary>
        /// Representa de forma genérica o Código da Publicação.
        /// </summary>
        public string Codigo { get; private set; }

        /// <summary>
        /// Guarda o estado da Publicação, ativou ou não.
        /// </summary>
        public bool Disponibilidade { get; protected set; }

        /// <summary>
        /// Representa de forma genérica o Autor da Publicação.
        /// </summary>
        public Pessoa autor { get; private set; }

        /// <summary>
        /// Instancia um objeto do tipo Publicação.
        /// </summary>
        /// <param name="titulo">Titulo da Publicação.</param>
        /// <param name="anoPublicacao">Ano que Publicação foi lançada.</param>
        /// <param name="codigo">Código da Publicação.</param>
        /// <param name="autorDaPubli">Autor da Publicação.</param>
        public Publicacao(string titulo, double anoPublicacao, string codigo, Pessoa autorDaPubli)
        {
            Titulo = titulo;
            AnoPublicacao = anoPublicacao;
            Codigo = codigo;
            autor = autorDaPubli;
            Disponibilidade = true;
        }

        /// <summary>
        /// Valida se Publicação está disponível ou não.
        /// </summary>
        /// <returns></returns>
        public bool IsDisponivel()
        {
            return Disponibilidade;
        }

        /// <summary>
        /// Muda o estado de Disponibilidade pra Emprestado.
        /// </summary>
        public void MarcarComoEmprestado()
        {
            Disponibilidade = false;
        }

        /// <summary>
        /// Muda o estado de Disponibilidade pra Disponível.
        /// </summary>
        public void MarcarComoDisponivel()
        {
            Disponibilidade = true;
        }
    }
}
