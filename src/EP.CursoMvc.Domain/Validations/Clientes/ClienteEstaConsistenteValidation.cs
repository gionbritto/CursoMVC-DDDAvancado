using DomainValidation.Validation;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var cpfCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(cpfCliente, "Cliente informou um CPF inválido"));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente Informou um e-mail inválido"));
            base.Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maior idade para cadastro"));
        }

        
    }
}
