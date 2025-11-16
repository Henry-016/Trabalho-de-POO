using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;

namespace ProjetinDePOO.FactoryMethod
{
    /// <summary>
    /// Responsável por criar um objeto do tipo Pessoa de uma forma indireta.
    /// </summary>
    public class PessoaFactory
    {
        /// <summary>
        /// Valida qual tipo de Pessoa deve criar (Leitor ou Autor)
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Pessoa CriarPessoa(string tipo, string nome, string? cpf)
        {
            switch (tipo.ToLower())
            {
                case "leitor":

                    return new Leitor(nome, cpf);

                case "autor":

                    return new Autor(nome);

                default:

                    throw new ArgumentException($"Tipo de material '{tipo}' não reconhecido. Use 'Leitor' ou 'Autor'!");
            }
        }
    }
}