using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories.Implementation
{
    public class FileContentFactory : IFileContentFactory
    {
        public FileContent CreateFromFile(string filePath) => new FileContent(System.IO.File.ReadAllText(filePath));
    }
}