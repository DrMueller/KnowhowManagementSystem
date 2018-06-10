using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories.Implementation.FileContentStrategies.StrategyImplementations
{
    public class TextFileContentStrategy : IFileContentStrategy
    {
        public FileType FileType => FileType.TextFile;

        public string ReadContent(string filePath)
        {
            // Here
            return null;
        }
    }
}