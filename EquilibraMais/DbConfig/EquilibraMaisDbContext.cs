using EquilibraMais.Model;
using Microsoft.EntityFrameworkCore;

namespace EquilibraMais.DbConfig;

public class EquilibraMaisDbContext :DbContext
{
    public EquilibraMaisDbContext(DbContextOptions<EquilibraMaisDbContext> options) : base(options) { }
    
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Funcionario_Info> FuncionarioInfos { get; set; }
}