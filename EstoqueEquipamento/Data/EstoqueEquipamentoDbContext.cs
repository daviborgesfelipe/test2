using EstoqueEquipamento.Data.Mappings;
using EstoqueEquipamento.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueEquipamento.Data
{
    public class EstoqueEquipamentoDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public EstoqueEquipamentoDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
      
            optionsBuilder.UseSqlServer(
                _config.GetConnectionString("CONECTION_DATABASE")
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChamadoMap());
            modelBuilder.ApplyConfiguration(new EquipamentoMap());
        }
    }
}
