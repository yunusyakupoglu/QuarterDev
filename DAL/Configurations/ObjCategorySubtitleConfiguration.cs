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
    public class ObjCategorySubtitleConfiguration : IEntityTypeConfiguration<ObjCategorySubtitle>
    {
        public void Configure(EntityTypeBuilder<ObjCategorySubtitle> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
