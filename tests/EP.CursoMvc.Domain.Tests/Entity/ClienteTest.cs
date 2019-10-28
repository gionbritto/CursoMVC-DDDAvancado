using System;
using System.Linq;
using EP.CursoMvc.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTest
    {
        //exxemplo de teste: boneco
        public Cliente Cliente { get; set; }

        /// <summary>
        /// testar para saber se o cliente esta sabendo se consistir direito.
        /// se atentar para o nome padrao dos testes
        /// :O que vou testar(Cliente consistente), o retorno(_Valid) e o tipo do retorno(_true, _false, etc)
        /// AQUI ESTOU TESTANDO A CLASSE ClienteEstaConsistenteValidation por completo, ou seja, testando os erros que essa classe deve cobrir
        /// </summary>
        [TestMethod]
        public void ClienteConsistente_Valid_True()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822",
                DataNascimento = new DateTime(1982, 01, 01),
                Email = "cliente@cliente.com.br"
            };

            //assert é o metodo que da a resposta para o teste
            //=> Verifique se o cliente "is valid()"
            Assert.IsTrue(Cliente.IsValid()); //aqui quero q ele retorne true, vou passar infos verdadeiras
        }

        /// <summary>
        /// Não realizamos a validacao fazendo com que o teste _Valid_true retorne um erro, mas sim criamos um outro metodo
        /// dizendo na especificacao que vou esperar um retorno false e passo valores falsos para que o FALSE aconteça
        /// </summary>
        [TestMethod]
        public void ClienteConsistente_Valid_False() //provocando para que o resultado seja faise
        {
            Cliente = new Cliente()
            {
                CPF = "30390612322",
                DataNascimento = new DateTime(2005, 01, 01),
                Email = "cliente20cliente.com.br"
            };

            //assert é o metodo que da a resposta para o teste
            //=> Verifique se o cliente "is valid()"
            Assert.IsFalse(Cliente.IsValid()); //aqui quero q ele retorne true, vou passar infos verdadeiras
            //aqui vou apontar os erros em espefico utilizando o DomainValidation.ValidatioResult (Tem que instalar ele neste projeto)
            //minha classe de clienteconsistente validation vai retornar esses erros abaixo, entao caso qualquer uma dessas mensagens,
            //não sejam retornadas no teste, significa que algo falhou, ou seja, o retorno do teste falso não retornou o que deveria
            //além de garantir que ele está falhando, tenho q garantir q está falhando para todas as validações de erros
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido"));
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente Informou um e-mail inválido"));
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maior idade para cadastro"));
        }
    }
}
