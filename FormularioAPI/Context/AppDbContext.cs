using FormularioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormularioAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Pergunta> Perguntas { get; set; }
    public DbSet<Resposta> Respostas { get; set; }
    public DbSet<Formulario> Formularios { get; set; }

}