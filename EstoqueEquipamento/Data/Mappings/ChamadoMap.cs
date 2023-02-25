using EstoqueEquipamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueEquipamento.Data.Mappings
{
    internal class ChamadoMap : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamado");
            builder.HasKey(chamado => chamado.Id);
            builder
                .Property(chamado => chamado.Descricao)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(chamado => chamado.DataAbertura)
                .HasColumnName("DataAbertura")
                .HasColumnType("datetime")
                .IsRequired();
            builder
                .Property(chamado => chamado.EquipamentoId)
                .HasColumnName("IdEquipamento")
                .HasColumnType("int")
                .IsRequired();
            builder
                .HasOne<Equipamento>(chamado => chamado.Equipamento)
                .WithMany(equipamento => equipamento.Chamados)
                .HasForeignKey(chamado => chamado.EquipamentoId);
        }
    }
}
