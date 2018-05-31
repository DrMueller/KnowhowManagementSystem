using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using StructureMap;

namespace Mmu.Kms.DomainServices.DataAccess.Infrastructure.DependencyInjection
{
    public class DomainServicesDataAccessRegistry : Registry
    {
        public DomainServicesDataAccessRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(DomainServicesDataAccessRegistry));
                    scanner.AddAllTypesOf(typeof(IRepository<>));
                    scanner.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                    scanner.WithDefaultConventions();
                });
        }
    }
}