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
    public class ObjAboutUsConfiguration : IEntityTypeConfiguration<ObjAboutUs>
    {
        public void Configure(EntityTypeBuilder<ObjAboutUs> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
