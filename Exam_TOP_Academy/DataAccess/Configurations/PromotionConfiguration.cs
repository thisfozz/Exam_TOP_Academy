using Exam_TOP_Academy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_TOP_Academy.DataAccess.Configurations;

internal class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.HasKey(e => e.PromotionId).HasName("promotion_pkey");

        builder.ToTable("promotion");

        builder.HasIndex(e => e.PromotionName, "promotion_promotion_name_key").IsUnique();

        builder.Property(e => e.PromotionId).HasColumnName("promotion_id");
        builder.Property(e => e.Description)
            .HasMaxLength(255)
            .HasColumnName("description");
        builder.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
        builder.Property(e => e.EndDate).HasColumnName("end_date");
        builder.Property(e => e.IsActivePromotion).HasColumnName("is_active_promotion");
        builder.Property(e => e.PromotionName)
            .HasMaxLength(100)
            .HasColumnName("promotion_name");
        builder.Property(e => e.StartDate).HasColumnName("start_date");
    }
}
