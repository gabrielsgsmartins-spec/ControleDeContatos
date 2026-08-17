using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {

    }

    public DbSet<ContatoModel> Contatos { get; set; }
}
