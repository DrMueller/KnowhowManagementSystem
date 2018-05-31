using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.Areas.Repositories
{
    public interface IFileRepository
    {
        void SaveFiles(IReadOnlyCollection<File> files);

        Task<File> LoadbyFilePathAsync(string filePath);
    }
}