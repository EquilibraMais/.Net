
# ⚙️ EquilibraMais - Projeto .NET (Api de Clima Organizacional)

### 👥 Integrantes do Projeto

- **Gustavo de Aguiar Lima Silva** - RM: 557707  
- **Julio Cesar Conceição Rodrigues** - RM: 557298  
- **Matheus de Freitas Silva** - RM: 552602  

---

### 💡 Descrição da Solução

Este projeto em .NET 9 utiliza Minimal APIs e Entity Framework Core para fornecer uma API de gestão e relatório de clima organizacional. Possui funcionalidades para cadastro e consulta de funcionários e seus indicadores de humor, energia, carga e sono, e relatórios agregados por setor e empresa.
---

### 🛠️ Como Executar o Projeto Localmente

#### ✅ Pré-requisitos

Certifique-se de ter instalado:

- [.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download)
- Acesso a um banco Azure SQL
- Uma IDE como **Rider**, **Visual Studio 2022+** ou **VS Code** com extensões C#

---

#### 🚀 Executando o Projeto

1. Clone ou extraia o repositório:

```bash
git clone https://github.com/EquilibraMais/.Net.git
cd .Net
cd EquilibraMais
```

2. Configure a connection string em `appsettings.json`:

```json
"ConnectionStrings": {
  "AzureSqlDb": //Adicionar posteriormente
}
```

3. Execute o projeto:

```bash
dotnet run --project EquilibraMais.sln
```

### 📦 Tecnologias Utilizadas

- .NET 9
- Entity Framework Core + Azure SQL
- Minimal APIs
- Scalar.AspNetCore (interface gráfica)
- OpenAPI
- Helpcheck para análise de saúde da API
- C#

---

### 📬 Como Usar a API Localmente

Você pode interagir com os endpoints da API usando **Scalar UI**, **Postman**, **curl** ou navegando pelas URLs diretamente.

---

## 📋 Tabela de Endpoints da API

V1 - Contém os edpoints simples para CRUD
V2 - Contém os endpoints para relatórios detalhados por Setor (/api/v2/relatorios/humor-medio-por-setor) e Empresa no geral (/api/v2/relatorios/humor).

| Entidade         | Método HTTP | Rota                                     | Descrição                                      |
|------------------|-------------|------------------------------------------|------------------------------------------------|
| Empresa          | GET         | /api/v1/empresas                        | Retorna todas as empresas                       |
| Empresa          | GET         | /api/v1/empresas/{id}                   | Retorna uma empresa por ID                       |
| Empresa          | POST        | /api/v1/empresas/inserir                | Insere uma nova empresa                          |
| Empresa          | PUT         | /api/v1/empresas/atualizar/{id}         | Atualiza uma empresa                             |
| Empresa          | DELETE      | /api/v1/empresas/deletar/{id}           | Remove uma empresa pelo ID                       |
| Setor            | GET         | /api/v1/setores                         | Retorna todos os setores                         |
| Setor            | GET         | /api/v1/setores/{id}                    | Retorna um setor por ID                          |
| Setor            | POST        | /api/v1/setores/inserir                 | Insere um novo setor                             |
| Setor            | PUT         | /api/v1/setores/atualizar/{id}          | Atualiza um setor                                |
| Setor            | DELETE      | /api/v1/setores/deletar/{id}            | Remove um setor pelo ID                          |
| Usuario          | GET         | /api/v1/usuarios                        | Retorna todos os usuários                        |
| Usuario          | GET         | /api/v1/usuarios/{id}                   | Retorna um usuário por ID                        |
| Usuario          | POST        | /api/v1/usuarios/inserir                | Insere um novo usuário                           |
| Usuario          | PUT         | /api/v1/usuarios/atualizar/{id}         | Atualiza um usuário                              |
| Usuario          | DELETE      | /api/v1/usuarios/deletar/{id}           | Remove um usuário pelo ID                        |
| Funcionario_Info | GET         | /api/v1/funcionario_infos               | Retorna todos os registros de funcionário        |
| Funcionario_Info | GET         | /api/v1/funcionario_infos/{id}          | Retorna um registro de funcionário por ID        |
| Funcionario_Info | GET         | /api/v1/funcionario_infos/user_id/{id}  | Retorna um registro de funcionário por ID de Usuário|
| Funcionario_Info | GET         | /api/v1/funcionario_infos/user_id/{id}/date/{date}| Retorna um registro de funcionário por ID de Usuário e Data de registro (Obs: A data precisa ser no modelo 'YYYY-MM-DD')|
| Funcionario_Info | POST        | /api/v1/funcionario_infos/inserir       | Insere um registro de funcionário                |
| Funcionario_Info | PUT         | /api/v1/funcionario_infos/atualizar/{id}| Atualiza um registro de funcionário              |
| Funcionario_Info | DELETE      | /api/v1/funcionario_infos/deletar/{id}  | Remove um registro de funcionário pelo ID        |
| Relatorios       | GET         | /api/v2/relatorios/humor                      | Retorna relatório agregando humor por setor e empresa |
| Relatorios       | GET         | /api/v2/relatorios/humor-medio-por-setor      | Retorna humor médio por setor                    |

---

### 🧪 Executando os Testes

1. Pré-requisitos:
   - API configurada conforme instruções acima.
   - Banco disponível e pré-populado conforme necessidade dos testes.
   - Projeto EquilibraMais.Tests referenciando a API.

2. No terminal:
   
dotnet test
