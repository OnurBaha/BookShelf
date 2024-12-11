using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder.ToTable("Books").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Author).HasColumnName("Author").IsRequired();
        builder.Property(b => b.Category).HasColumnName("Category").IsRequired();
        builder.Property(b => b.BookImage).HasColumnName("BookImage").IsRequired();
        builder.Property(b => b.Rating ).HasColumnName("Rating").IsRequired();
        builder.Property(b => b.IsRead).HasColumnName("IsRead").IsRequired();
        builder.Property(b => b.IsFavorite).HasColumnName("IsFavorite").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.AddedDate).HasColumnName("AddedDate").HasDefaultValueSql("GETUTCDATE()").IsRequired();
        

        builder.HasQueryFilter(rp => !rp.DeletedDate.HasValue);
    }
}
