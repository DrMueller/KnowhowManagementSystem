using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.Areas.Factories
{
    public interface IFileTagFactory
    {
        FileTag CreateFileTag(string name, string description, string id = null);
    }
}