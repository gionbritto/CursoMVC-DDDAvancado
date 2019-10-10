using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Entities.Service;
using EP.CursoMvc.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace EP.CursoMvc.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public Cliente Adicionar(Cliente obj)
        {
            return _clienteRepository.Adicionar(obj);
        }

        public Cliente Atualizar(Cliente obj)
        {
            return _clienteRepository.Atualizar(obj);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this); //destroi esta instancia
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
