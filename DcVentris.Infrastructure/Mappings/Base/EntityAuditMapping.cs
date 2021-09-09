using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DcVentris.Domain.Entities.Base;

namespace DcVentris.Infrastructure.Mappings.Base
{
    public class EntityAuditMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityAudit
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(entityAudt => entityAudt.ModificadoPor)
                .HasColumnName("modificado_por")
                .IsRequired();

            builder.Property(entityAudt => entityAudt.DataDeCriacaoNoFormatoUTC)
                .HasColumnName("data_criacao_utc")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(entityAudt => entityAudt.DataDaModificacaoNoFormatoUTC)
                .HasColumnName("data_modificacao_utc")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
        }
    }
}
