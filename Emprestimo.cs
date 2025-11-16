using ProjetinDePOO.Excecoes;
using ProjetinDePOO.Strategy;

namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa o Vínculo entre uma Publicação e um Leitor
    /// </summary>
    public class Emprestimo
    {
        /// <summary>
        /// Representa a Publicação Emprestada.
        /// </summary>
        public Publicacao PublicacaoEmprestada { get; private set; }
        
        /// <summary>
        /// Representa O Leitor que pediu o Emprestimo.
        /// </summary>
        public Leitor LeitorDoEmprestimo { get; private set; }

        /// <summary>
        /// Representa a Data que a Publicacação foi emprestada a um Leitor.
        /// </summary>
        public DateTime DataEmprestimo { get; private set; }

        /// <summary>
        /// Representa a Data que a Publicação foi devolvida a Biblioteca.
        /// </summary>
        public DateTime? DataDevolucao { get; private set; }

        /// <summary>
        /// Guarda uma referência de ICalculoStrategy para alterar as taxas aplicadas por atraso.
        /// </summary>
        private readonly ICalculoMultaStrategy _calculoStrategy;

        /// <summary>
        /// Instacia um objeto do tipo Emprestimo.
        /// </summary>
        /// <param name="publi">Publicação Emprestada.</param>
        /// <param name="leitor">Leitor Contratante.</param>
        /// <param name="calculoStrategy">Tipo de Multa que será aplicada em caso de atraso.</param>
        public Emprestimo(Publicacao publi, Leitor leitor, ICalculoMultaStrategy calculoStrategy)
        {
            PublicacaoEmprestada = publi;
            LeitorDoEmprestimo = leitor;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
            _calculoStrategy = calculoStrategy;
        }

        /// <summary>
        /// Tem como objetivo validar e guardar a data que a Publicação foi devolvido.
        /// </summary>
        /// <param name="date">Data que a Publicação foi devolvida.</param>
        /// <exception cref="ArgumentException">Valida se data passada é consistente.</exception>
        public void Devolver(DateTime date)
        {
            if (date < DataEmprestimo)
            {
                throw new ArgumentException("A data de devolução não pode ser anterior à data do empréstimo.");
            }

            DataDevolucao = date;
        }

        /// <summary>
        /// Valida se o Leitor atrasou na devolução.
        /// </summary>
        /// <returns></returns>
        private TimeSpan CalcularDuracao()
        {
            DateTime dataDev = DataDevolucao ?? DateTime.Now;

            TimeSpan resultado = dataDev - DataEmprestimo;

            return resultado;
        }

        /// <summary>
        /// Aplica a multa por atraso caso Leitor tenha passado do prazo estipulado.
        /// </summary>
        /// <returns></returns>
        public decimal CalcularMulta()
        {
            TimeSpan duracao = CalcularDuracao();
            return _calculoStrategy.Calcular(duracao);
        }
    }
}
