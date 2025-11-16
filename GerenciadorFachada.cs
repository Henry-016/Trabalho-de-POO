using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;
using ProjetinDePOO.Strategy;

namespace ProjetinDePOO.Façade
{
    /// <summary>
    /// É uma fachada do GerenciadorDeServicos, apenas delega as responsabilidades.
    /// </summary>
    public class GerenciadorFachada : IGerenciadorDeServicos
    {
        private readonly IGerenciadorDeServicos _servico;
        public GerenciadorFachada(IGerenciadorDeServicos servico)
        {
            _servico = servico;
        }

        public void CadastrarPublicacao(Publicacao publicacao) 
        { 
            _servico.CadastrarPublicacao(publicacao);
        }

        public void RemoverPublicacaoCadastrada(string codigo) 
        { 
            _servico.RemoverPublicacaoCadastrada(codigo);
        }

        public void CadastrarLeitor(Leitor leitor) 
        { 
            _servico.CadastrarLeitor(leitor);
        }

        public void RemoverLeitorCadastrado(string cpf) 
        {
            _servico.RemoverLeitorCadastrado(cpf);
        }

        public void EmprestarPublicacao(string CPF, string codigo, ICalculoMultaStrategy _novaStrategy) 
        {
            _servico.EmprestarPublicacao(CPF, codigo, _novaStrategy);
        }

        public void DevolverPublicacao(string CPF, string codigo, DateTime dataDaDevolucao) 
        { 
            _servico.DevolverPublicacao(CPF, codigo, dataDaDevolucao);
        }

        public void ProcessarPagamento(string cpf, decimal valorPago) 
        {
            _servico.ProcessarPagamento(cpf, valorPago);
        }
        public IReadOnlyList<Leitor> ListarLeitores()
        {
            return _servico.ListarLeitores();
        }

        public IReadOnlyList<Publicacao> ListarAcervo()
        {
            return _servico.ListarAcervo();
        }
    }
}
