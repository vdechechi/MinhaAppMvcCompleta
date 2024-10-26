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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(MeuDbContext context):base(context) { }
      
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            var result = await Db
                .Produtos
                .AsNoTracking()
                .Include(p => p.Fornecedor)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();    

            return result;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            var produtos = await Db.Produtos.AsNoTracking().Include(p => p.Fornecedor).OrderBy(p => p.Nome).ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedores(Guid fornecedorId)
        {
            var produtos = await Buscar(p=> p.FornecedorId == fornecedorId);    

            return produtos;
        }
    }
}
