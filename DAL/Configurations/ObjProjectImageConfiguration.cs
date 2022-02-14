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
	public class ObjProjectImageConfiguration : IEntityTypeConfiguration<ObjProjectImage>
	{
		public void Configure(EntityTypeBuilder<ObjProjectImage> builder)
		{
			builder.Property(x => x.ImagePath).IsRequired();
			builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
		}
	}
}
