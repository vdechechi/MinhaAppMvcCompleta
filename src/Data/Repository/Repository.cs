using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() //new() para dizer que posso fazer uma instancia
    {


        protected readonly MeuDbContext Db; //Protected por tanto Repository quanto quem herdar dele vai ter acesso ao DbContext
        protected readonly DbSet<TEntity> DbSet; //Protected por tanto Repository quanto quem herdar dele vai ter acesso ao DbContext

        protected Repository(MeuDbContext db)
        {
            Db  = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).ToListAsync(); //predicate é uma expressao 

            return result;

            
        }

        public virtual async Task<TEntity> ObterPorId(Guid id) //Virtual pois me permitirá reescrever o metodo quando necessário
        {
            var result = await DbSet.FindAsync(id);

            return result;
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            var result = await DbSet.ToListAsync();

            return result;

        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            var entity = new TEntity { Id = id };

            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        } 
    }
}
