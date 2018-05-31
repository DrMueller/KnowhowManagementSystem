using Mmu.Kms.Domain;
using Mmu.Kms.DomainServices.Areas.Factories;
using Mmu.Mlh.DataAccess.Areas.IdGeneration;

namespace Mmu.Kms.DomainServices.Shell.Areas.Factories
{
    public class FileTagFactory : IFileTagFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public FileTagFactory(IEntityIdFactory entityIdFactory)
        {
            _entityIdFactory = entityIdFactory;
        }

        public FileTag CreateFileTag(string name, string description, string id = null) => new FileTag(id ?? _entityIdFactory.CreateEntityId(), name, description);
    }
}