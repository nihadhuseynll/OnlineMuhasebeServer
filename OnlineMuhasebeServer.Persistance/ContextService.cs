using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance
{
	public sealed class ContextService : IContextService
	{
		private readonly AppDbContext _context;

		public ContextService(AppDbContext context)
		{
			_context = context;
		}

		public DbContext CreateDbContextInstance(string companyId)
		{
			Company company = _context.Set<Company>().Find(companyId);
			return new CompanyDbContext(company);	
		}
	}
}
