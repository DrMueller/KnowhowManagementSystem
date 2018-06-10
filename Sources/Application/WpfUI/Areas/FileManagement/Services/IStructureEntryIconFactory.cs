using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Services
{
    public interface IStructureEntryIconFactory
    {
        string CreateIconPathForDirectory();

        string CreateIconPathForFile(FileTypeDto fileType);
    }
}