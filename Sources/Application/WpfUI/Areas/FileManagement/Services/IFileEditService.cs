using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services
{
    public interface IFileEditService
    {
        Task EditFileAsync(FileDto dto);
    }
}