namespace ProjetinDePOO.Entidades
{
    /// <summary>
    /// Representa uma entidade genérica Pessoa.
    /// </summary>
    public abstract class Pessoa
    {
        /// <summary>
        /// Representa de uma forma genérica o Nome da Pessoa.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Representa de uma forma genérica o CPF de uma Pessoa.
        /// </summary>
        public string CPF { get; private set; }

        /// <summary>
        /// Instacia um objeto do tipo Pessoa apenas com o Nome.
        /// </summary>
        /// <param name="nome"></param>
        public Pessoa(string nome)
        {
            Nome = nome;
            CPF = null;
        }

        /// <summary>
        /// Instancia um objeto do tipo Pessoa com Nome e CPF.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        public Pessoa(string nome, string cpf) : this(nome)
        {
            CPF = cpf;
        }
    }
}