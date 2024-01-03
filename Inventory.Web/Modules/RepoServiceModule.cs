using Autofac;
using Inventory.Core.Repositories;
using Inventory.Core.Services;
using Inventory.Core.UnitOfWorks;
using Inventory.Repository;
using Inventory.Repository.Repositories;
using Inventory.Repository.UnitOfWorks;
using Inventory.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace Inventory.Web.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var repoAssembly = Assembly.GetAssembly(typeof(InventoryDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(Service<>));

            builder.RegisterAssemblyTypes(repoAssembly!,serviceAssembly!).Where(x=> x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repoAssembly!,serviceAssembly!).Where(x=> x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
