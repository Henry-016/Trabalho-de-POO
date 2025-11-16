using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;

namespace ProjetinDePOO.Repository
{
    /// <summary>
    /// Responsável por gerenciar todos os Leitores da Biblioteca.
    /// </summary>
    public class LeitorRepository : ILeitorRepository
    {
        private Dictionary<string, Leitor> _leitoresCadastrados;

        /// <summary>
        /// Cria uma instância de LeitorRepository
        /// </summary>
        public LeitorRepository()
        {
            _leitoresCadastrados = new Dictionary<string, Leitor>(); ;
        }

        /// <summary>
        /// Responsável por encontrar o Leitor com base no CPF fornecido.
        /// </summary>
        /// <param name="cpf">CPF do Leitor desejado.</param>
        /// <returns></returns>
        public Leitor EncontrarLeitor(string cpf)
        {
            if (_leitoresCadastrados.TryGetValue(cpf, out Leitor leitor))
            {
                return leitor;
            }

            return null;
        }

        /// <summary>
        /// Responsável por registrar um Leitor na Biblioteca.
        /// </summary>
        /// <param name="leitor">Leitor em questão que será cadastrado.</param>
        public void AdicionarLeitor(Leitor leitor)
        {
            _leitoresCadastrados.Add(leitor.CPF, leitor);
        }

        /// <summary>
        /// Responsável por remover um Leitor da Biblioteca.
        /// </summary>
        /// <param name="leitor">Leitor em questão que será removido.</param>
        public void RemoverLeitor(Leitor leitor)
        {
            _leitoresCadastrados.Remove(leitor.CPF);
        }

        /// <summary>
        /// Responsável por retornar todos os Leitores cadastrados na Biblioteca.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Leitor> GetTodosLeitores()
        {
            return _leitoresCadastrados.Values.ToList().AsReadOnly();
        }
    }
}
