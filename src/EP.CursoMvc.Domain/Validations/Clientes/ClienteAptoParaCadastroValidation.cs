using DomainValidation.Validation;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Specifications;
using EP.CursoMvc.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteEndereco = new ClienteDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF Já cadastrado"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E -mail já cadastrado!"));
            base.Add("clienteEndereco", new Rule<Cliente>(clienteEndereco, "Cliente deve possuir pelo menos um endereço!"));
        }
    }
}
