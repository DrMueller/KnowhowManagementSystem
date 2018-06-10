using System.Linq;
using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories.Implementation.FileContentStrategies.Implementation
{
    public class FileContentStrategyFactory : IFileContentStrategyFactory
    {
        private readonly IFileContentStrategy[] _strategies;

        public FileContentStrategyFactory(IFileContentStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public IFileContentStrategy Create(FileType fileType)
        {
            return _strategies.First(f => f.FileType == fileType);
        }
    }
}