public interface IPessoaRepository
{
	Task<IEnumerable<Pessoa>> ObterTodasPessoas();
	Task<Pessoa> ObterPessoaPorId(int id);
	Task AdicionarPessoa(Pessoa pessoa);
	Task AtualizarPessoa(Pessoa pessoa);
	Task DeletarPessoa(int id);
}
