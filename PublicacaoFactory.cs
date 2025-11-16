using ProjetinDePOO.Entidades;

namespace ProjetinDePOO.FactoryMethod
{
    /// <summary>
    /// Responsável por criar um objeto do tipo Publicação de uma forma indireta.
    /// </summary>
    public class PublicacaoFactory
    {
        /// <summary>
        /// Valida qual o tipo de Publicação deve criar (Livro ou Monografia)
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="tituloDaPublicacao"></param>
        /// <param name="anoDaPublicacao"></param>
        /// <param name="codigoDaPublicacao"></param>
        /// <param name="autorDaPublicacao"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Publicacao CriarPublicacao(string tipo, string tituloDaPublicacao, double anoDaPublicacao, string codigoDaPublicacao, Pessoa autorDaPublicacao)
        {
            switch (tipo.ToLower())
            {
                case "livro":

                    return new Livro(tituloDaPublicacao, anoDaPublicacao, codigoDaPublicacao, autorDaPublicacao);

                case "monografia":

                    return new Monografia(tituloDaPublicacao, anoDaPublicacao, codigoDaPublicacao, autorDaPublicacao);

                default:

                    throw new ArgumentException($"Tipo de material '{tipo}' não reconhecido. Use 'Livro' ou 'Monografia'!");
            }
        }
    }
}