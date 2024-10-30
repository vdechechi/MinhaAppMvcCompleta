using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class ProdutoService : BaseService, IProdutoService

    {
        public Task Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
