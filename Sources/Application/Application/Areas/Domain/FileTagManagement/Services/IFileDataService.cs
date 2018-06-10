using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.FileTagManagement.Services
{
    public interface IFileDataService
    {
        Task SaveAsync(FileDto dto);
    }
}