﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Repositories
{
	public class CommandRepository<T> : ICommandRepository<T>
		where T : Entity
	{

		private static readonly Func<CompanyDbContext, string, Task<T>>
			GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
			context.Set<T>().FirstOrDefault(x => x.Id == id));


		private CompanyDbContext _context;
		public DbSet<T> Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void CreateDbContextInstance(DbContext context)
		{
			_context = (CompanyDbContext)context;
			Entity = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await Entity.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
		    await Entity.AddRangeAsync(entities);
		}

		public void Remove(T entity)
		{
			Entity.Remove(entity);
		}

		public async Task RemoveById(string id)
		{
			T entity = await GetByIdCompiled(_context, id);
			Remove(entity);	
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			Entity.RemoveRange(entities);
		}

		public void Update(T entity)
		{
			Entity.Update(entity);	
		}

		public void UpdateRange(IEnumerable<T> entities)
		{
			Entity.UpdateRange(entities);
		}
	}
}
