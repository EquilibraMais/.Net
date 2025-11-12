using EquilibraMais.DbConfig;
using EquilibraMais.Model;
using Microsoft.EntityFrameworkCore;

namespace EquilibraMais.Controller;

public class Funcionario_InfoEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
    group.MapGroup("/funcionarios_info").WithTags("Funcionario_info").RequireAuthorization();
        
        //Get all
        group.MapGet("/funcionarios_info", async (EquilibraMaisDbContext db) =>
            await db.FuncionarioInfos.ToListAsync())
            .Produces<Funcionario_Info>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Retorna todas as informações dos funcionários")
            .WithDescription("Retorna todas as informações dos funcionários cadastradas no banco de dados, " +
                             "mesmo que só seja encontrado um funcionário, ele ainda vai retornar uma lista");

        //GetById
        group.MapGet("/funcionarios_info/{id}", async (int id, EquilibraMaisDbContext db) =>
        {
            var funcionarioInfo = await db.FuncionarioInfos.FindAsync(id);
            return funcionarioInfo is not null ? Results.Ok(funcionarioInfo) : Results.NotFound();
        })
        .Produces<Funcionario_Info>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Busca a informação de um usuário pelo ID das informações")
        .WithDescription("Retorna os dados de um funcionário específico com base no ID informado. " +
                         "Caso o ID não exista, retorna 404 Not Found.");
        
        // Inserir
        group.MapPost("/funcionarios_info/inserir", async (Funcionario_Info funcionarioInfo, EquilibraMaisDbContext db) =>
            {
                if (funcionarioInfo == null)
                    return Results.BadRequest("Dados inválidos.");
                
                db.FuncionarioInfos.Add(funcionarioInfo);
                await db.SaveChangesAsync();
                return Results.Created($"/funcionarios_info/{funcionarioInfo.Id}", funcionarioInfo);
            })
            .Produces<Funcionario_Info>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Accepts<Funcionario_Info>("application/json")
            .WithSummary("Insere uma nova informação de funcionário")
            .WithDescription("Adiciona uma nova informação de funcionário ao banco de dados com base nos dados enviados no corpo da requisição.");
        
        // Atualizar
        group.MapPut("/funcionarios_info/atualizar/{id}", async (int id, Funcionario_Info funcionarios_info, EquilibraMaisDbContext db) =>
        {
            var existing = await db.FuncionarioInfos.FindAsync(id);
            if (existing == null) 
                return Results.NotFound();
            
            existing.Humor = funcionarios_info.Humor;
            existing.Carga = funcionarios_info.Carga;
            existing.Energia = funcionarios_info.Energia;
            existing.Sono = funcionarios_info.Carga;
            existing.Observacao = funcionarios_info.Observacao;
            existing.Historico_medico = funcionarios_info.Historico_medico;
            await db.SaveChangesAsync();

            return Results.Ok($"Informações de funcionário com ID {id} atualizado com sucesso.");
        })
        .Produces<Funcionario_Info>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Accepts<Funcionario_Info>("application/json")
        .WithSummary("Atualiza uma informação de funcionário existente")
        .WithDescription("Atualiza os dados de um funcionário já cadastrado, identificado pelo ID. " +
                         "Caso o ID não exista, retorna 404 Not Found.");
        
        // Deletar
        group.MapDelete("/funcionarios_info/deletar/{id}", async (int id, EquilibraMaisDbContext db) =>
            {
                var funcionarios_info = await db.FuncionarioInfos.FindAsync(id);
                if (funcionarios_info == null) 
                    return Results.NotFound();

                db.FuncionarioInfos.Remove(funcionarios_info);
                await db.SaveChangesAsync();
                
                return Results.Ok($"Informações de funcionário com ID {id} removido com sucesso.");
            })
            .Produces<Funcionario_Info>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Remove a informação de um funcionário")
        .WithDescription("Remove a informação de um funcionário do banco de dados com base no ID informado. " +
                         "Caso as informações não seja encontradas, retorna 404 Not Found.");
    }
}