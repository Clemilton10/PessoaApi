using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Abrindo o arquivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Pegando a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PessoaDb");

// Configure o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite(connectionString));

// Registre o repositório no contêiner de injeção de dependência
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
	// Configura o Swagger em ambiente de desenvolvimento
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pessoa API", Version = "v1" });
	});
}


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cria o banco de dados e aplica as migrações na inicialização
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();

	// Swagger na Home(só na webapi)
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "PessoaApi");
	});
	// Sem o Swagger na Home
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
