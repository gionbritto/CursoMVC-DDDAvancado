using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Validations.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    //É obrigatorio implementar esta interface
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}
