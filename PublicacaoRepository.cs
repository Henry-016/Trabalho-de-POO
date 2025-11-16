using ProjetinDePOO.Entidades;
using System;

namespace ProjetinDePOO.Repository
{
    /// <summary>
    /// Responsável por gerenciar todos as Publicações do acervo da Biblioteca.
    /// </summary>
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private Dictionary<string, Publicacao> _acervo; // Como Funciona? Estudar!

        public PublicacaoRepository()
        {
            _acervo = new Dictionary<string, Publicacao>();
        }

        /// <summary>
        /// Responsável por encontrar a Publicação com base no Código fornecido.
        /// </summary>
        /// <param name="codigo">Código da Publicação desejada.</param>
        /// <returns></returns>
        public Publicacao EncontrarPublicacao(string codigo)
        {
            if (_acervo.TryGetValue(codigo, out Publicacao publi))
            {
                return publi;
            }

            return null;
        }

        /// <summary>
        /// Responsável por registrar uma Publicação no acervo da Biblioteca.
        /// </summary>
        /// <param name="publi">Publicação em questão que será cadastrada.</param>
        public void AdicionarPublicacao(Publicacao publi)
        {
            _acervo.Add(publi.Codigo, publi);
        }

        /// <summary>
        /// Responsável por remover uma Publicação do acervo da Biblioteca.
        /// </summary>
        /// <param name="publicacao">Publicação em questão que será removida.</param>
        public void RemoverPublicacao(Publicacao publicacao)
        {
            _acervo.Remove(publicacao.Codigo);
        }

        /// <summary>
        /// Responsável por retornar todos as Publicações presentes no Acervo da Biblioteca.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Publicacao> GetTodasPublicacoes()
        {
            return _acervo.Values.ToList().AsReadOnly();
        }

        /// <summary>
        /// Responsável por limpar todo o Acervo.
        /// </summary>
        public void ApagarTudo()
        {
            _acervo.Clear();
        }
    }
}
