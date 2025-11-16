using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;
using ProjetinDePOO.Repository;
using ProjetinDePOO.Strategy;

namespace ProjetinDePOO.Façade
{
    /// <summary>
    /// Responsável por gerenciar todos os processos da Biblioteca.
    /// </summary>
    public class GerenciadorDeServicos : IGerenciadorDeServicos
    {
        private readonly IPublicacaoRepository _pubRepository;
        private readonly ILeitorRepository _leitorRepository;
        private readonly Biblioteca _biblioteca;

        /// <summary>
        /// Cria uma instância de GerenciadorDeServicos.
        /// </summary>
        /// <param name="pubRep">Acervo da Biblioteca.</param>
        /// <param name="leitorRep">Local onde tá guardado os Leitores cadastrados.</param>
        /// <param name="biblioteca">Biblioteca associada.</param>
        public GerenciadorDeServicos(IPublicacaoRepository pubRep, ILeitorRepository leitorRep, Biblioteca biblioteca)
        {
            _pubRepository = pubRep;
            _leitorRepository = leitorRep;
            _biblioteca = biblioteca;
        }

        /// <summary>
        /// Responsável por fazer as verificações necessárias e delega o cadastro ao PublicacaoRepository.
        /// </summary>
        /// <param name="publicacao">Publicação a ser cadastrada.</param>
        /// <exception cref="LivroJaExistenteException">Verifica se Publicação já está cadastrada.</exception>
        public void CadastrarPublicacao(Publicacao publicacao)
        {

            Publicacao isExiste = _pubRepository.EncontrarPublicacao(publicacao.Codigo);

            if (isExiste != null) { throw new LivroJaExistenteException($"Código de Publicação duplicado! Já existe um item com o código '{publicacao.Codigo}' no acervo. Use um código exclusivo para cada item."); }

            _pubRepository.AdicionarPublicacao(publicacao);
        }

        /// <summary>
        /// Responsável por fazer as verificações necessárias e delega a remoção ao PublicacaoRepository.
        /// </summary>
        /// <param name="codigo">Código da Publicação a ser removida do Acervo.</param>
        /// <exception cref="LivroNaoEncontradoException">Verifica se Publicação existe no Acervo.</exception>
        /// <exception cref="LivroIndisponivelException">Verifica se Publicação foi emprestada.</exception>
        public void RemoverPublicacaoCadastrada(string codigo)
        {
            Publicacao pub = _pubRepository.EncontrarPublicacao(codigo);

            if (pub == null) { throw new LivroNaoEncontradoException("Publicação não encontrada no acervo."); }

            if (!pub.IsDisponivel()) { throw new LivroIndisponivelException($"A publicação '{pub.Titulo}' está emprestada e não pode ser removida."); }

            _pubRepository.RemoverPublicacao(pub);
        }

        /// <summary>
        /// Responsável por fazer as verificações necessárias e delega o cadastro ao LeitorRepository.
        /// </summary>
        /// <param name="leitor">Leitor em questão que será cadastrado.</param>
        /// <exception cref="LeitorJaCadastradoException">Verifica se Leitor já está cadastrado.</exception>
        public void CadastrarLeitor(Leitor leitor)
        {
            Leitor isExiste = _leitorRepository.EncontrarLeitor(leitor.CPF);

            if (isExiste != null) { throw new LeitorJaCadastradoException($"{isExiste.Nome} já está cadastrado em nosso sistema!"); }

            _leitorRepository.AdicionarLeitor(leitor);
        }

        /// <summary>
        /// Responsável por fazer as verificações necessárias e delega a remoção ao LeitorRepository.
        /// </summary>
        /// <param name="cpf">CPF do Leitor que será removido.</param>
        /// <exception cref="LeitorNaoCadastradoException">Verifica se Leitor já está cadastrado.</exception>
        /// <exception cref="LeitorEmDebitoException">Verifica se o Leitor possui pendência com a Biblioteca.</exception>
        /// <exception cref="LeitorComLivrosEmPosse">Verifica se Leitor tem empréstimos ativos.</exception>
        public void RemoverLeitorCadastrado(string cpf)
        {
            Leitor leitor = _leitorRepository.EncontrarLeitor(cpf);

            if (leitor == null) { throw new LeitorNaoCadastradoException("Leitor não encontrado no sistema."); }

            if (leitor.EstaEmDebito()) { throw new LeitorEmDebitoException($"O leitor possui uma dívida pendente de R${leitor.DividaAtual:F2} e não pode ser removido."); }

            if (leitor.LivrosEmPosse.Any()) { throw new LeitorComLivrosEmPosse("O leitor ainda possui publicações ativas e deve devolvê-las antes de ser removido."); }

            _leitorRepository.RemoverLeitor(leitor);
        }

        /// <summary>
        /// Responsável por fazer as verificações e emprestar uma Publicação a um Leitor.
        /// </summary>
        /// <param name="CPF">CPF do Leitor que receberá o Leitor.</param>
        /// <param name="codigo">Código da Publicação que será emprestada.</param>
        /// <param name="_novaStrategy">Multa que será aplicada.</param>
        /// <exception cref="LivroNaoEncontradoException">Verifica se Publicação existe no Acervo.</exception>
        /// <exception cref="LeitorNaoCadastradoException">Verifica se Leitor foi cadastrado.</exception>
        /// <exception cref="LeitorEmDebitoException">Verifica se Leitor possui débito.</exception>
        /// <exception cref="LivroIndisponivelException">Verifica se a Publicação está disponível pra empréstimo.</exception>
        public void EmprestarPublicacao(string CPF, string codigo, ICalculoMultaStrategy _novaStrategy)
        {
            Publicacao publiDesejada = _pubRepository.EncontrarPublicacao(codigo);
            Leitor leitorCadastrado = _leitorRepository.EncontrarLeitor(CPF);

            if (publiDesejada == null) { throw new LivroNaoEncontradoException("Publicação não encontrada! Verifique se o código está correto e se o item pertence ao acervo."); }
            if (leitorCadastrado == null) { throw new LeitorNaoCadastradoException("Leitor não encontrado. Por favor, verifique o CPF ou cadastre-se primeiro (Opção 1)."); }
            if (leitorCadastrado.EstaEmDebito()) { throw new LeitorEmDebitoException($"Bloqueado! O leitor possui uma dívida de R${leitorCadastrado.DividaAtual}. Pague a dívida para fazer novos empréstimos!"); }
            if (!publiDesejada.IsDisponivel()) { throw new LivroIndisponivelException("Essa publicação está atualmente emprestada! Consulte a disponibilidade ou tente novamente mais tarde."); }

            publiDesejada.MarcarComoEmprestado();

            Emprestimo novoEmprestimo = new Emprestimo(publiDesejada, leitorCadastrado, _novaStrategy);
            leitorCadastrado.AdicionarEmprestimoAtivo(novoEmprestimo);
        }

        /// <summary>
        /// Retira o Livro da posse do Leitor e devolve o Acervo da Biblioteca.
        /// </summary>
        /// <param name="CPF">CPF do Leitor que está com a Publicação.</param>
        /// <param name="codigo">Código da Publicação que será devolvida.</param>
        /// <param name="dataDaDevolucao">Data que a Publicação foi devolvida.</param>
        /// <exception cref="LeitorNaoCadastradoException">Verifica se Leitor foi cadastrado.</exception>
        /// <exception cref="EmprestimoNaoRealizadoException">Verifica se a Publicação em questão foi emprestada em algum momento e está ativa.</exception>
        public void DevolverPublicacao(string CPF, string codigo, DateTime dataDaDevolucao)
        {
            Leitor leitorCadastrado = _leitorRepository.EncontrarLeitor(CPF);

            if (leitorCadastrado == null) { throw new LeitorNaoCadastradoException("Leitor não encontrado. Por favor, verifique o CPF ou cadastre-se primeiro (Opção 1)"); }

            Emprestimo emprestimoAtivo = null;

            foreach (Emprestimo emp in leitorCadastrado.LivrosEmPosse)
            {
                if (emp.PublicacaoEmprestada.Codigo == codigo)
                {
                    emprestimoAtivo = emp;
                    break;
                }
            }

            if (emprestimoAtivo == null) { throw new EmprestimoNaoRealizadoException($"Transação não encontrada: Não há registros de empréstimo ativo para o código '{codigo}' e o CPF informado. O livro já foi devolvido ou o código está errado."); }

            emprestimoAtivo.Devolver(dataDaDevolucao);

            decimal divida = emprestimoAtivo.CalcularMulta();

            leitorCadastrado.AtualizarDivida(divida);

            leitorCadastrado.RemoverEmprestimoAtivo(emprestimoAtivo);
            emprestimoAtivo.PublicacaoEmprestada.MarcarComoDisponivel();
        }

        /// <summary>
        /// Responsável por quitar os débitos do Leitor.
        /// </summary>
        /// <param name="cpf">CPF do Leitor em questão.</param>
        /// <param name="valorPago">Valor a ser pago para quitar dívida.</param>
        /// <exception cref="LeitorNaoCadastradoException">Verifica se Leitor foi cadastrado.</exception>
        /// <exception cref="ArgumentException">Verifica se os valores passados são válidos.</exception>
        public void ProcessarPagamento(string cpf, decimal valorPago)
        {
            Leitor leitor = _leitorRepository.EncontrarLeitor(cpf);

            if (leitor == null) { throw new LeitorNaoCadastradoException("Leitor não encontrado. Verifique o CPF."); }

            if (valorPago <= 0) { throw new ArgumentException("O valor do pagamento deve ser positivo."); }

            leitor.PagarDivida(valorPago);
        }

        /// <summary>
        /// Delega responsabilidade pro LeitorRepository e retorna todos Leitores cadastrados.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Leitor> ListarLeitores()
        {
            return _leitorRepository.GetTodosLeitores();
        }

        /// <summary>
        /// Delega responsabilidade pro PublicacaoRepository e retorna todas as Publicações presentes no Acervo.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Publicacao> ListarAcervo()
        {
            return _pubRepository.GetTodasPublicacoes();
        }
    }
}
