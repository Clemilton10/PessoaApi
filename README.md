# Instalação

```sh
dotnet new webapi -n PessoaApi -f net6.0
cd PessoaApi
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.24
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.24
dotnet add package Swashbuckle.AspNetCore --version 6.5.0

# Listar pacotes
dotnet list package

# instalar pacotes pelo XML
dotnet restore

# Remover pacotes
dotnet remove package nome

# Limpar
dotnet clean

# Executar
dotnet watch run
```

# Versões do banco de dados

```sh
# Criar um migrations
dotnet ef migrations add Inicial

# Criar um banco de dados
dotnet ef database update
```
