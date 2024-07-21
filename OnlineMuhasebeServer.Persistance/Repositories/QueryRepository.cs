using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Repositories
{
	public class QueryRepository<T> : IQueryRepository<T>
		where T : Entity
	{

		private static readonly Func<CompanyDbContext, string, Task<T>>
			GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault());

		private static readonly Func<CompanyDbContext,Task<T>>
			GetFirstCompiled = EF.CompileAsyncQuery((CompanyDbContext context) => context.Set<T>().FirstOrDefault());

		private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>>
			GetFirstByExpressionCompiled = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression) =>
			(context.Set<T>().FirstOrDefault(expression)));
			


		private CompanyDbContext _context;
		public DbSet<T> Entity { get ; set ; }

		public void SetDbContextInstance(DbContext context)
		{
			_context=(CompanyDbContext)context;	
			Entity=_context.Set<T>();	
		}

		public IQueryable<T> GetAll()
		{
			return Entity.AsQueryable();
		}

		public async Task<T> GetById(string id)
		{
			return await GetByIdCompiled(_context, id);
		}

		public Task<T> GetFirst()
		{
			return GetFirstCompiled(_context);
		}

		public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression)
		{
			return await GetFirstByExpressionCompiled(_context, expression);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
		{
			return Entity.Where(expression);
		}
	}
}
