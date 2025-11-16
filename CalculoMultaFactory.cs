using ProjetinDePOO.Strategy;

namespace ProjetinDePOO.FactoryMethod
{
    /// <summary>
    /// Responsável por criar um objeto do tipo ICalculoMultaStrategy de uma forma indireta.
    /// </summary>
    public class CalculoMultaFactory
    {
        /// <summary>
        /// Valida qual tipo de Multa deve ser aplicada (Premium ou Padrão)
        /// </summary>
        /// <param name="tipoMulta"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICalculoMultaStrategy CriarStrategy(string tipoMulta)
        {
            switch (tipoMulta.ToLower())
            {
                case "1":
                case "padrao":
                    return new MultaPadraoStrategy();

                case "2":
                case "premium":
                    return new MultaPremiumStrategy();

                default:
                    throw new ArgumentException("Opção de multa inválida.");
            }
        }
    }
}
