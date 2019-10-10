using EP.CursoMvc.Application;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Domain.Entities.Service;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Service;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Interfaces;
using EP.CursoMvc.Infra.Data.Repository;
using EP.CursoMvc.Infra.Data.UoW;
using SimpleInjector;

namespace EP.CursoMvc.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Local on eu defino as dependencias
    /// </summary>
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Transient => Uma instancia para cada solicitacao
            //Singleton => Uma instancia unida para a classe
            //Scoped => Uma instancia unica para o request (um usuario nao ira concorrer com o outro)
            
            //app
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped); //a classe precisa implementar o contrato senão ele não resolve

            //infra dados
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);

        }
    }
}
