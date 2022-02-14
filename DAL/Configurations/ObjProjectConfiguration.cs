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
	public class ObjProjectConfiguration : IEntityTypeConfiguration<ObjProject>
	{
		public void Configure(EntityTypeBuilder<ObjProject> builder)
		{
			builder.Property(x => x.ImagePath).IsRequired();
			builder.Property(x => x.BrandName).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.ProjectType).IsRequired();
			builder.Property(x => x.Title).IsRequired();
			builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
		}
	}
}
