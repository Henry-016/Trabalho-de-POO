using ProjetinDePOO.Excecoes;
using System;

namespace ProjetinDePOO.Repository
{
    /// <summary>
    /// Representa um contrato que mantém dados do Leitor.
    /// </summary>
    public interface ILeitorRepository
    {
        Leitor EncontrarLeitor(string cpf);
        void AdicionarLeitor(Leitor leitor);
        void RemoverLeitor(Leitor leitor);
        IReadOnlyList<Leitor> GetTodosLeitores();
    }
}
