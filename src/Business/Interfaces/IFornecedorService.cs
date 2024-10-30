using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFornecedorService
    {

        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task AtualizarEndereco(Endereco endereco);
        Task Remover(Guid id);


    }
}