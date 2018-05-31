using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Factories
{
    public interface IFileContentFactory
    {
        FileContent CreateFromFile(string filePath);
    }
}