using System;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpeficicationTest
    {
        public Cliente Cliente { get; set; }
        [TestMethod]
        public void CPF_Valid_True()
        {
            Cliente = new Cliente()
            {
                CPF = "10215551699"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsTrue(cpf.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void CPF_Valid_False()
        {
            Cliente = new Cliente()
            {
                CPF = "10215551612"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsFalse(cpf.IsSatisfiedBy(Cliente));
        }
    }
}
