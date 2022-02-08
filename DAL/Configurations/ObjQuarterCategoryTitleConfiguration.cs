using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ObjQuarterCategoryTitleConfiguration : IEntityTypeConfiguration<ObjQuarterCategoryTitle>
    {
        public void Configure(EntityTypeBuilder<ObjQuarterCategoryTitle> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.ToTable("QuarterCategoryTitles");
        }
    }
}
