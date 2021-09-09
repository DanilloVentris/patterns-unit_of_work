using DcVentris.Domain.Entities;
using DcVentris.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DcVentris.Infrastructure.Mappings
{
    public class UserMapping : EntityAuditMapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Usuario");

            builder.Property(usuario => usuario.PrimeiroNome)
                .HasColumnName("Nome")
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(usuario => usuario.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasMaxLength(80)
                .HasColumnType("nvarchar(80)")
                .IsRequired();

            builder.HasIndex(usuario => usuario.Email)
                .IsUnique();

            builder.Property(usuario => usuario.Email)
                .HasColumnName("Email")
                .HasMaxLength(80)
                .HasColumnType("nvarchar(80)")                
                .IsRequired();
        }
    }
}
