# Sobre o projeto
ProConsultation é uma plataforma desenvolvida em Blazor que facilita a consulta e agendamento de consultas médicas. A aplicação permite que pacientes encontrem médicos, visualizem suas especialidades e realizem agendamentos.

# Tecnologias utilizadas

- .NET 8
- Blazor
- C#
- SQLSERVER

# Pré-requisitos

Antes de começar, você precisará das seguintes ferramentas instaladas:

- .NET 8 [Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server [Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

# Como executar o projeto

```bash
# clonar repositório
git clone https://github.com/diogosalvadorb/ProConsultation.git
cd Proconsultation

# configure sua conexão 
editar sua conexao no appsettings.json

"ConnectionStrings":
  "DefaultConnection": (Sua conexão)

# instala dependências 
dotnet restore

# subir base do banco de dados
update-database

# executar o projeto
dotnet run
```

# Interface do projeto
![Dashboard](https://github.com/diogosalvadorb/ProConsultation/blob/main/Proconsultation/Imagens/Home.png)
![Agendamento](https://github.com/diogosalvadorb/ProConsultation/blob/main/Proconsultation/Imagens/Agendamento.png)
![Medicos](https://github.com/diogosalvadorb/ProConsultation/blob/main/Proconsultation/Imagens/Medicos.png)
