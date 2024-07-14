using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Configurations
{
	public sealed class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
	{
		public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
		{
			builder.ToTable(TableNames.UniformChartOfAccounts);
			builder.HasKey(p => p.Id);
		}
	}
}
