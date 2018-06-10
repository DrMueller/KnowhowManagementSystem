using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories.Implementation.FileContentStrategies
{
    public interface IFileContentStrategyFactory
    {
        IFileContentStrategy Create(FileType fileType);
    }
}
