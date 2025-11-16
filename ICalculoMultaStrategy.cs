using System;

namespace ProjetinDePOO.Strategy
{
    /// <summary>
    /// Representa uma multa genérica.
    /// </summary>
    public interface ICalculoMultaStrategy
    {
        decimal Calcular(TimeSpan duracaoEmprestimo);
    }
}
