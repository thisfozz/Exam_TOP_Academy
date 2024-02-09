using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;

internal class RegistereduserConfiguration : IEntityTypeConfiguration<Registereduser>
{
    public void Configure(EntityTypeBuilder<Registereduser> builder)
    {
        builder.HasKey(e => e.UserId).HasName("registeredusers_pkey");

        builder.ToTable("registeredusers");

        builder.Property(e => e.UserId).HasColumnName("user_id");
        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .HasColumnName("email");
        builder.Property(e => e.Login)
            .HasMaxLength(15)
            .HasColumnName("login");
        builder.Property(e => e.Password)
            .HasMaxLength(255)
            .HasColumnName("password");
    }
}