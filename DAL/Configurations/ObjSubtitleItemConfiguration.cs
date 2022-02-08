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
    public class ObjSubtitleItemConfiguration : IEntityTypeConfiguration<ObjSubtitleItem>
    {
        public void Configure(EntityTypeBuilder<ObjSubtitleItem> builder)
        {
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
