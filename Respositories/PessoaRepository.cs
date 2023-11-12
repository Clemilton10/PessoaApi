using Microsoft.EntityFrameworkCore;

public class PessoaRepository : IPessoaRepository
{
	private readonly AppDbContext _context;

	public PessoaRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Pessoa>> ObterTodasPessoas()
	{
		return await _context.Pessoas.ToListAsync();
	}

	public async Task<Pessoa> ObterPessoaPorId(int id)
	{
		return await _context.Pessoas.FindAsync(id);
	}

	public async Task AdicionarPessoa(Pessoa pessoa)
	{
		_context.Pessoas.Add(pessoa);
		await _context.SaveChangesAsync();
	}

	public async Task AtualizarPessoa(Pessoa pessoa)
	{
		_context.Entry(pessoa).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeletarPessoa(int id)
	{
		var pessoa = await _context.Pessoas.FindAsync(id);
		if (pessoa != null)
		{
			_context.Pessoas.Remove(pessoa);
			await _context.SaveChangesAsync();
		}
	}
}
