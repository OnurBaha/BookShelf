using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ReadingPlanConfiguration : IEntityTypeConfiguration<ReadingPlan>
    {
        public void Configure(EntityTypeBuilder<ReadingPlan> builder)
        {
            builder.ToTable("ReadingPlans").HasKey(rp => rp.Id);

            builder.Property(rp => rp.Id).HasColumnName("Id").IsRequired();
            builder.Property(rp => rp.UserName).HasColumnName("Username").IsRequired();
            builder.Property(rp => rp.StartDate).HasColumnName("StartDate").HasDefaultValueSql("GETUTCDATE()").IsRequired();
            builder.Property(rp => rp.EndDate).HasColumnName("EndDate").IsRequired();
            builder.HasMany(rp => rp.Books).WithMany().UsingEntity(j => j.ToTable("ReadingPlanBooks"));

            builder.HasQueryFilter(rp => !rp.DeletedDate.HasValue);
        }
    }
}
