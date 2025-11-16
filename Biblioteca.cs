using System;

namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa a entidade Biblioteca.
    /// </summary>
    public class Biblioteca
    {
        /// <summary>
        /// Representa o CNPJ da Biblioteca.
        /// </summary>
        public string CNPJ { get; private set; }

        /// <summary>
        /// Representa o Local Físico da Bilioteca.
        /// </summary>
        public string Endereco { get; private set; }

        /// <summary>
        /// Representa o Nome da Biblioteca.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Representa o Contato da Bilioteca.
        /// </summary>
        public string Telefone { get; private set; }

        /// <summary>
        /// Instancia um objeto do tipo Biblioteca;
        /// </summary>
        /// <param name="cnpjDaBiblioteca">CNPJ da Biblioteca</param>
        /// <param name="enderecoDaBiblioteca">Endereço da Biblioteca</param>
        /// <param name="nomeDaBiblioteca">Nome da Biblioteca</param>
        /// <param name="telefoneDaBiblioteca">Contato da Biblioteca</param>
        public Biblioteca(string cnpjDaBiblioteca, string enderecoDaBiblioteca, string nomeDaBiblioteca, string telefoneDaBiblioteca)
        {
            CNPJ = cnpjDaBiblioteca;
            Endereco = enderecoDaBiblioteca;
            Nome = nomeDaBiblioteca;
            Telefone = telefoneDaBiblioteca;
        }
    }
}
