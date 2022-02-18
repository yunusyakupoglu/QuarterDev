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
	public class ObjCustomerConfiguration : IEntityTypeConfiguration<ObjCustomer>
	{
		public void Configure(EntityTypeBuilder<ObjCustomer> builder)
		{
			builder.Property(x => x.CustomerName).IsRequired();
			builder.Property(x => x.CustomerSurName).IsRequired();
			builder.Property(x => x.CustomerPhone).IsRequired();
			builder.Property(x => x.CustomerMail).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.ProductType).IsRequired();
			builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

		}
	}
}
