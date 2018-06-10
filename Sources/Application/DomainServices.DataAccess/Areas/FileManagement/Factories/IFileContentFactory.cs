using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Factories
{
    public interface IFileContentFactory
    {
        FileContent CreateFromFile(string filePath);
    }
}