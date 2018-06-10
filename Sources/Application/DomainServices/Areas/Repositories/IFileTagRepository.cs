using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Domain;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;

namespace Mmu.Kms.DomainServices.Areas.Repositories
{
    public interface IFileTagRepository : IRepository<FileTag>
    {
        Task<IReadOnlyCollection<FileTag>> LoadAsyncByNames(IReadOnlyCollection<string> fileTagNames);

        Task<IReadOnlyCollection<FileTag>> LoadByIdsAsync(IReadOnlyCollection<string> ids);
    }
}