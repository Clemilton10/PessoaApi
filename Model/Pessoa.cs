using System.ComponentModel.DataAnnotations;

public class Pessoa
{
	public int Id { get; set; }
	[Required]
	[StringLength(255, MinimumLength = 3)]
	public string Nome { get; set; }
	[Required]
	[StringLength(11, MinimumLength = 10)]
	public string Telefone { get; set; }
}
public class PessoaBase
{
	[Required]
	[StringLength(255, MinimumLength = 3)]
	public string Nome { get; set; }
	[Required]
	[StringLength(11, MinimumLength = 10)]
	public string Telefone { get; set; }
}
