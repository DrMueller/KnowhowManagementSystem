using Mmu.Kms.DomainServices.Shell.Areas.Services.Servants;
using Mmu.Kms.DomainServices.Shell.Areas.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Kms.DomainServices.Shell.Infrastructure.DependencyInjection
{
    public class DomainServicesShellRegistry : Registry
    {
        public DomainServicesShellRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(DomainServicesShellRegistry));
                    scanner.WithDefaultConventions();
                });

            For<IDirectoryServant>().Use<DirectoryServant>();
        }
    }
}