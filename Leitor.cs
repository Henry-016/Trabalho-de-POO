using ProjetinDePOO.Entidades;
using System;

namespace ProjetinDePOO.Excecoes
{
    /// <summary>
    /// Representa a entidade Leitor.
    /// </summary>
    public class Leitor : Pessoa
    {
        /// <summary>
        /// Guarda o histórico de Emprestimo que solicitou em todo seu tempo de vida, ativos ou não.
        /// </summary>
        private List<Emprestimo> _historicoEmprestimos;
        public IReadOnlyList<Emprestimo> HistoricoEmprestimos => _historicoEmprestimos.AsReadOnly(); // O que é isso? Entender

        /// <summary>
        /// Guarda os Emprestimos ativos no momento.
        /// </summary>
        private List<Emprestimo> _livrosEmPosse; // Uma lista de referências dos empréstimos ativos para consultas rápidas
        public IReadOnlyList<Emprestimo> LivrosEmPosse => _livrosEmPosse.AsReadOnly();

        /// <summary>
        /// Representa a dívida que o Leitor tem com a Biblioteca.
        /// </summary>
        public decimal DividaAtual { get; private set; }

        /// <summary>
        /// Instancia um objeto do tipo Leitor.
        /// </summary>
        /// <param name="nome">Nome do Leitor.</param>
        /// <param name="cpf">CPF do Leitor.</param>
        public Leitor(string nome, string cpf) : base(nome, cpf)
        {
            _historicoEmprestimos = new List<Emprestimo>();
            _livrosEmPosse = new List<Emprestimo>();
        }

        /// <summary>
        /// Responsável por arquivar os empréstimos.
        /// </summary>
        /// <param name="emprestimo"></param>
        public void AdicionarEmprestimoAtivo(Emprestimo emprestimo)
        {
            _historicoEmprestimos.Add(emprestimo);
            _livrosEmPosse.Add(emprestimo);
        }

        /// <summary>
        /// Responsável pro remover os empréstimos ativos.
        /// </summary>
        /// <param name="emprestimo"></param>
        public void RemoverEmprestimoAtivo(Emprestimo emprestimo)
        {
            _livrosEmPosse.Remove(emprestimo);
        }

        /// <summary>
        /// Responsável por atualizar a dívida do Leitor.
        /// </summary>
        /// <param name="valor"></param>
        public void AtualizarDivida(decimal valor)
        {
            DividaAtual += valor;

            if (DividaAtual < 0)
            {
                DividaAtual = 0;
            }
        }

        /// <summary>
        /// Verifica se Leitor está devendo a Biblioteca.
        /// </summary>
        /// <returns></returns>
        public bool EstaEmDebito()
        {
            return DividaAtual > 0;
        }

        /// <summary>
        /// Responsável por quitar a dívida do Leitor, caso possua.
        /// </summary>
        /// <param name="valor"></param>
        public void PagarDivida(decimal valor)
        {
            DividaAtual -= valor;

            if (DividaAtual < 0m)
            {
                DividaAtual = 0m;
            }
        }
    }
}