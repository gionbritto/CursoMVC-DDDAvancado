using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirEmailUnico : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteDevePossuirEmailUnico(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}
