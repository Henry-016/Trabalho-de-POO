using System;

namespace ProjetinDePOO.Strategy
{
    /// <summary>
    /// Representa uma Multa padrão específica.
    /// </summary>
    public class MultaPadraoStrategy : ICalculoMultaStrategy
    {
        /// <summary>
        /// Representa a taxa que será aplicado por dia de atraso.
        /// </summary>
        private const decimal TaxaDiaria = 1.27m;

        /// <summary>
        /// Representa o prazo máximo pra devolução sem que haja multa.
        /// </summary>
        private const int PrazoDias = 14;

        /// <summary>
        /// Calcula a Multa que será aplicada utilizando os critérios padrões.
        /// </summary>
        /// <param name="duracao">Tempo que Leitor ficou com a Publicação.</param>
        /// <returns></returns>
        public decimal Calcular(TimeSpan duracao)
        {
            double diasTotais = duracao.TotalDays;
            double diasParaMultar = Math.Max(0, Math.Floor(diasTotais - PrazoDias));

            return (decimal)diasParaMultar * TaxaDiaria;
        }
    }
}
