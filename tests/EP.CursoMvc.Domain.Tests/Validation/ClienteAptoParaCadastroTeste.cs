using System;
using System.Linq;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTeste
    {
        public Cliente Cliente { get; set; }
        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "cad@cad.com.br"
            };
            Cliente.Enderecos.Add(new Endereco());

            //vou gerar um mock de um repositorio (quem conecta no banco seria o IClienteRepository) 
            //lembrando que não uso implementações e sim abstrações
            //**Um Stub é uma simulação do tipo
            var stupRepo = MockRepository.GenerateStub<IClienteRepository>();
            //como se estivesse pedindo para achar um cara com esse email e falo o resultado
            //vicio ele dizendo q vai retornar nulo
            stupRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(null);
            stupRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(null);

            var cliValidation = new ClienteAptoParaCadastroValidation(stupRepo);
            Assert.IsTrue(cliValidation.Validate(Cliente).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "cad@cad.com.br"
            };
            //Cliente.Enderecos.Add(new Endereco());

            var stupRepo = MockRepository.GenerateStub<IClienteRepository>();
            
            stupRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(Cliente);
            stupRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(Cliente);

            var cliValidation = new ClienteAptoParaCadastroValidation(stupRepo);
            var result = cliValidation.Validate(Cliente);

            Assert.IsFalse(cliValidation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF Já cadastrado"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E -mail já cadastrado!"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente deve possuir pelo menos um endereço!"));
            

        }
    }
}
