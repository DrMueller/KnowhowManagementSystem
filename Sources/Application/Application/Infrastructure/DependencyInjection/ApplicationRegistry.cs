using StructureMap;

namespace Mmu.Kms.Application.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(ApplicationRegistry));
                    scanner.WithDefaultConventions();
                });
        }
    }
}