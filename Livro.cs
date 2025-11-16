using System;

namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa a entidade Livro.
    /// </summary>
    public class Livro : Publicacao
    {
        /// <summary>
        /// Instancia um objeto do tipo Livro.
        /// </summary>
        /// <param name="tituloDaObra">Titulo do Livro.</param>
        /// <param name="anoDaPublicacao">Ano que o Livro foi Publicado.</param>
        /// <param name="codigoDoLivro">Código que representa o Livro.</param>
        /// <param name="autorDoLivro">Nome do Autor que escreveu o Livro.</param>
        public Livro(string tituloDaObra, double anoDaPublicacao, string codigoDoLivro, Pessoa autorDoLivro) : base(tituloDaObra, anoDaPublicacao, codigoDoLivro, autorDoLivro) {}

    }
}
