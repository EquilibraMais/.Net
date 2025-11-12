using EquilibraMais.Controller;
using EquilibraMais.DbConfig;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<EquilibraMaisDbContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

        builder.Services.AddOpenApi();
        
        builder.Services.AddHealthChecks();
        
        var app = builder.Build();

        app.MapHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        var v1 = app.MapGroup("/api/v1");
        
        EmpresaEndpoints.Map(v1);
        Funcionario_InfoEndpoints.Map(v1);
        SetorEndpoints.Map(v1);
        UsuarioEndpoints.Map(v1);

        await app.RunAsync();
    }
}