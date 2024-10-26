using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity //Oferecer todos os metodos necessarios para cada entidade, pois é generico e deve ser um filho de entity
    {
        Task Adicionar(TEntity entity); //Qualquer entidade que for filha de entity vai ser aceita

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);

        Task Remover(Guid id);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate); //Passe uma expressao lamba por dentro do metodo que vai comparar com uma TEntity e retorna um boolean

        Task<int> SaveChanges(); // int pois retorna o numero de linhas afetadas



    }
}
