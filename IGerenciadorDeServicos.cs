using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;
using ProjetinDePOO.Strategy;

namespace ProjetinDePOO.Façade
{
    public interface IGerenciadorDeServicos
    {
        public void CadastrarPublicacao(Publicacao publicacao);
        public void RemoverPublicacaoCadastrada(string codigo);
        public void CadastrarLeitor(Leitor leitor);
        public void RemoverLeitorCadastrado(string cpf);
        public void EmprestarPublicacao(string CPF, string codigo, ICalculoMultaStrategy _novaStrategy);
        public void DevolverPublicacao(string CPF, string codigo, DateTime dataDaDevolucao);
        public void ProcessarPagamento(string cpf, decimal valorPago);
        public IReadOnlyList<Leitor> ListarLeitores();
        public IReadOnlyList<Publicacao> ListarAcervo();
    }
}
