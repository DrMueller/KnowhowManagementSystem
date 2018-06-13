using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Services.Servants.Implementation
{
    public class StructureEntryIconFactory : IStructureEntryIconFactory
    {
        public string CreateIconPathForDirectory() => "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Arrow.png";

        public string CreateIconPathForFile(FileTypeDto fileType) => "/Mmu.Kms.WpfUI;component/Infrastructure/Assets/FA_Cog_Green.png";
    }
}