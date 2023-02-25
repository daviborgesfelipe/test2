using EstoqueEquipamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueEquipamento.Data.Mappings
{
    internal class EquipamentoMap : IEntityTypeConfiguration<Equipamento>    
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("Equipamento");
            builder.HasKey(equipamento => equipamento.Id);
            builder
                .Property(equipamento => equipamento.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(equipamento => equipamento.Preco)
                .HasColumnName("Preco")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(equipamento => equipamento.NumeroSerie)
                .HasColumnName("NumeroSerie")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(equipamento => equipamento.DataFabricacao)
                .HasColumnName("DataFabricacao")
                .HasColumnType("datetime")
                .IsRequired(); 
            builder
                .Property(equipamento => equipamento.Fabricante)
                .HasColumnName("Fabricante")
                .IsRequired();
        }
    }
}
