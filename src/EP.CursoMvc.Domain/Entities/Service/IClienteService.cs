using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMvc.Domain.Entities.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente obj);
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente obj);
        void Remover(Guid id);
    }
}
