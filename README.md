# Trabalho-de-POO
Projeto para Composição de Nota da AB2 em POO 2025...

Vídeo: https://youtu.be/Vta3VvkxmTs

Para complementar o Diagrama de Classes, segue cada Classe com seus Respectivos Parâmetros:

Entities (Models):

Biblioteca (string cnpjDaBiblioteca, string enderecoDaBiblioteca, string nomeDaBiblioteca, string telefoneDaBiblioteca)
Pessoa (Sobrecarga 1: string nome) / (Sobrecarga 2: string nome, string cpf)
Leitor (string nome, string cpf)
Autor (string nome)
Publicacao (string titulo, double anoPublicacao, string codigo, Pessoa autorDaPubli)
Livro (string tituloDaObra, double anoDaPublicacao, string codigoDoLivro, Pessoa autorDoLivro)
Monografia (string tituloDaObra, double anoDaPublicacao, string codigoDaMono, Pessoa autorDaMonografia)
Emprestimo (Publicacao publi, Leitor leitor, ICalculoMultaStrategy calculoStrategy)
CalculoMultaFactory (Nenhum)
PessoaFactory (Nenhum)
PublicacaoFactory (Nenhum)
ICalculoMultaStrategy (Nenhum - Interface)
MultaPadraoStrategy (Nenhum)
MultaPremiumStrategy (Nenhum)

Controllers:

IGerenciadorDeServicos (Nenhum - Interface)
GerenciadorDeServicos (IPublicacaoRepository pubRep, ILeitorRepository leitorRep, Biblioteca biblioteca)
GerenciadorFachada (IGerenciadorDeServicos servico)
ILeitorRepository (Nenhum - Interface)
LeitorRepository (Nenhum)
IPublicacaoRepository (Nenhum - Interface)
PublicacaoRepository (Nenhum)

View:

InterfaceUsuario (GerenciadorFachada gerenciador, PublicacaoFactory publicacaoFactory, PessoaFactory pessoaFactory)
