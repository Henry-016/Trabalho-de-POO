using ProjetinDePOO.Entidades;
using System;

namespace ProjetinDePOO.Repository
{
    /// <summary>
    /// Representa um contrato que mantém dados de Publicação.
    /// </summary>
    public interface IPublicacaoRepository
    {
        Publicacao EncontrarPublicacao(string codigo);
        void AdicionarPublicacao(Publicacao publi);
        void RemoverPublicacao(Publicacao publicacao);
        IReadOnlyList<Publicacao> GetTodasPublicacoes();
    }
}
