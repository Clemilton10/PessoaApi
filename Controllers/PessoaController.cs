using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pessoas")]
public class PessoaController : ControllerBase
{
	private readonly IPessoaRepository _pessoaRepository;

	public PessoaController(IPessoaRepository pessoaRepository)
	{
		_pessoaRepository = pessoaRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Pessoa>>>
	GetPessoas()
	{
		var pessoas = await _pessoaRepository.ObterTodasPessoas();
		return Ok(pessoas);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Pessoa>> GetPessoa(int id)
	{
		var pessoa = await _pessoaRepository.ObterPessoaPorId(id);
		if (pessoa == null)
		{
			return NotFound();
		}
		return Ok(pessoa);
	}

	[HttpPost]
	public async Task<ActionResult<Pessoa>> PostPessoa(PessoaBase pessoa)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}
		var p = new Pessoa();
		p.Nome = pessoa.Nome;
		p.Telefone = pessoa.Telefone;
		await _pessoaRepository.AdicionarPessoa(p);
		return CreatedAtAction(nameof(GetPessoa), new { id = p.Id }, p);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutPessoa(int id, PessoaBase pessoa)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}
		var p = new Pessoa();
		p.Id = id;
		p.Nome = pessoa.Nome;
		p.Telefone = pessoa.Telefone;
		await _pessoaRepository.AtualizarPessoa(p);
		return Ok(p);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletePessoa(int id)
	{
		await _pessoaRepository.DeletarPessoa(id);
		return NoContent();
	}
}
