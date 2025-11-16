using System;

namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa a entidade Monografia.
    /// </summary>
    public class Monografia : Publicacao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tituloDaObra">Titulo do Monografia.</param>
        /// <param name="anoDaPublicacao">Ano que a Monografia foi Publicada.</param>
        /// <param name="codigoDaMono">Código que representa o Monografia.</param>
        /// <param name="autorDaMonografia">Nome do Autor que escreveu o Monografia.</param>
        public Monografia(string tituloDaObra, double anoDaPublicacao, string codigoDaMono, Pessoa autorDaMonografia) : base(tituloDaObra, anoDaPublicacao, codigoDaMono, autorDaMonografia) { }

    }
}
