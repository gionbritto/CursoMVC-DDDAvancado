using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;
using EP.CursoMvc.Domain.Validations.Clientes;
using System;
using System.Collections.Generic;

namespace EP.CursoMvc.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }       

        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}