using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {

        Task<Produto> ObterProdutoFornecedor(Guid id); //Lista de produtos e fornecedores daquele produto
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedores(Guid fornecedorId); //Retorna uma Lista de produtos por fornecedor
        Task<IEnumerable<Produto>> ObterProdutosFornecedores(); //Retorna um produto e seu fornecedor

       
    }
}
