using ProjetinDePOO.Entidades;
using ProjetinDePOO.Excecoes;
using ProjetinDePOO.Façade;
using ProjetinDePOO.FactoryMethod;
using ProjetinDePOO.Strategy;

public class InterfaceUsuario
{
    private GerenciadorFachada _gerenciador;
    private PublicacaoFactory _publicacaoFactory;
    private PessoaFactory _pessoaFactory;

    public InterfaceUsuario(GerenciadorFachada gerenciador, PublicacaoFactory publicacaoFactory, PessoaFactory pessoaFactory)
    {
        _gerenciador = gerenciador;
        _publicacaoFactory = publicacaoFactory;
        _pessoaFactory = pessoaFactory;
    }

    /// <summary>
    /// Console Principal, tudo que será exibido ao Usuário do Sistema.
    /// </summary>
    /// <exception cref="FormatException"></exception>
    public void Iniciar()
    {
        Console.WriteLine("Bem-vindo ao Sistema de Gerenciamento de Biblioteca!");
        bool rodando = true;

        while (rodando)
        {
            ExibirMenu();
            string opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "0":
                    {
                         Console.WriteLine("\n Obrigado e Volte Sempre! \n");

                         rodando = false;
                         break;
                    }

                    case "1":
                    {
                        Console.Write("\nQual o Nome do Leitor? ");
                        string nome = Console.ReadLine();
                        Console.Write("\nQual o CPF do Leitor? ");
                        string cpf = Console.ReadLine();

                        Leitor leitor = new Leitor(nome, cpf);

                        _gerenciador.CadastrarLeitor(leitor);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n{leitor.Nome} cadastrado com Sucesso!");
                        Console.ResetColor();
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("\n--- REMOVER LEITOR ---\n");
                        Console.Write("CPF do Leitor a ser removido: ");
                        string cpfRemocao = Console.ReadLine();

                        _gerenciador.RemoverLeitorCadastrado(cpfRemocao);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nSUCESSO! Leitor removido do sistema.");
                        Console.ResetColor();
                        break;
                    }

                    case "3":
                    {
                        Console.Write("\nDeseja Cadastrar um Livro ou uma Monografia? ");
                        string tipo = Console.ReadLine();
                        Console.Write("\nQual seria o nome da publicação? ");
                        string nome = Console.ReadLine();
                        Console.Write("\nQual seria a data da publicação? (aaaa) ");
                        double data = double.Parse(Console.ReadLine());
                        Console.Write("\nQual o código da publicação? ");
                        string codigo = Console.ReadLine();
                        Console.Write("\nQual o nome do Autor/Assinatura? ");
                        string nomeAutor = Console.ReadLine();

                        Publicacao publi = _publicacaoFactory.CriarPublicacao(tipo, nome, data, codigo, _pessoaFactory.CriarPessoa("Autor", nomeAutor, null));

                        _gerenciador.CadastrarPublicacao(publi);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n{publi.Titulo} Cadastrado com Sucesso!\n");
                        Console.ResetColor();
                        break;
                    }

                    case "4":
                    {
                        Console.Write("\n--- REMOVER PUBLICAÇÃO ---\n");
                        Console.Write("\nCódigo da Publicação a ser removida: ");
                        string codigoRemocao = Console.ReadLine();

                        _gerenciador.RemoverPublicacaoCadastrada(codigoRemocao);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nSUCESSO! Publicação com o código: {codigoRemocao} removida do acervo.");
                        Console.ResetColor();
                        break;
                    }

                    case "5":
                    {
                        Console.Write("\nQual o CPF do Leitor? ");
                        string CPF = Console.ReadLine();
                        Console.Write("\nQual o Código da Publicação? ");
                        string codigo = Console.ReadLine();

                        Console.Write("\n--- ESCOLHA A MULTA ---\n");
                        Console.Write("\nMulta Padrão (14 dias, 1.27/dia) - Digite: Padrão");
                        Console.Write("\nMulta Premium (14 dias, 2.07/dia) - Digite: Premium\n");
                        Console.Write("\nOpção: ");
                        string escolha = Console.ReadLine();

                        ICalculoMultaStrategy strategyEscolhida = CalculoMultaFactory.CriarStrategy(escolha);

                        _gerenciador.EmprestarPublicacao(CPF, codigo, strategyEscolhida);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nPublicação Emprestada com Sucesso!\n");
                        Console.ResetColor();
                        break;
                    }

                    case "6":
                    {
                        Console.Write("\nQual o CPF do Leitor? ");
                        string CPF = Console.ReadLine();
                        Console.Write("\nQual o Código da Publicação? ");
                        string codigo = Console.ReadLine();
                        Console.Write("\nQual a data de devolução (dd/mm/aaaa)? ");
                        string data = Console.ReadLine();

                        if (!DateTime.TryParse(data, out DateTime dataDevolucao)) { throw new FormatException("A data informada é inválida. Use o formato correto! (dd/mm/aaaa)"); }

                        _gerenciador.DevolverPublicacao(CPF, codigo, dataDevolucao);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nPublicação Devolvida com Sucesso!\n");
                        Console.ResetColor();
                        break;
                    }
                    case "7":
                    {
                        Console.Write("\n--- PAGAMENTO DE DÍVIDA ---\n");
                        Console.Write("\nCPF do Leitor: ");
                        string cpfPagamento = Console.ReadLine();

                        Console.Write("\nValor do pagamento: ");

                        if (!decimal.TryParse(Console.ReadLine(), out decimal valorPago)) { throw new FormatException("Valor de pagamento inválido."); }

                        _gerenciador.ProcessarPagamento(cpfPagamento, valorPago);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\nPagamento processado com sucesso!\n");
                        Console.ResetColor();
                        break;
                    }

                    case "8":
                    {
                        ExibirAcervo();
                        break;
                    }

                    case "9":
                    {
                        ExibirListaDeLeitores();
                        break;
                    }

                    case "10":
                    {
                        Console.Clear();
                        Console.WriteLine("Terminal limpo. Pressione Enter para exibir o Menu.");
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERRO: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Representa o Menu para que o Usuário saiba o que escolher.
    /// </summary>
    private void ExibirMenu()
    {
        Console.WriteLine("\n--- MENU PRINCIPAL ---\n");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Cadastrar Novo Leitor");
        Console.WriteLine("2. Remover Leitor Cadastrado");
        Console.WriteLine("3. Cadastrar Publicação");
        Console.WriteLine("4. Remover Publicação Cadastrada");
        Console.WriteLine("5. Emprestar uma Publicação");
        Console.WriteLine("6. Devolver uma Publicação");
        Console.WriteLine("7. Quitar Dívida de um Leitor");
        Console.WriteLine("8. Listar todo o Acervo");
        Console.WriteLine("9. Listar todos os Leitores Cadastrados");
        Console.WriteLine("10. Limpar o Terminal \n");
        Console.Write("Escolha uma opção: ");
    }

    /// <summary>
    /// Exibe o acervo de uma forma elegante.
    /// </summary>
    private void ExibirAcervo()
    {
        IReadOnlyList<Publicacao> acervo = _gerenciador.ListarAcervo();

        Console.WriteLine("\n--- ACERVO COMPLETO ---\n");

        if (acervo.Any())
        {
            foreach (Publicacao pub in acervo)
            {
                string status = pub.IsDisponivel() ? "Disponível" : "EMPRESTADO";

                Console.WriteLine($"[ {pub.Codigo} ] | Título: {pub.Titulo} | Ano: {pub.AnoPublicacao} | Status: {status}");
            }
        }
        else
        {
            Console.WriteLine("O acervo está vazio.");
        }
    }

    /// <summary>
    /// Exibe os Leitores cadastrados de uma forma elegante.
    /// </summary>
    private void ExibirListaDeLeitores()
    {
        IReadOnlyList<Leitor> leitores = _gerenciador.ListarLeitores();

        Console.WriteLine("\n--- LEITORES CADASTRADOS ---\n");

        if (leitores.Any())
        {
            foreach (Leitor leitor in leitores)
            {
                Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.CPF}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum leitor cadastrado.");
        }
    }
}