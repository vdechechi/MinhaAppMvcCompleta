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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {

        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            var result = await Db
                .Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            return result;
            
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            var result = await Db
                .Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f=> f.Produtos)
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            return result;

        }
    }
}
