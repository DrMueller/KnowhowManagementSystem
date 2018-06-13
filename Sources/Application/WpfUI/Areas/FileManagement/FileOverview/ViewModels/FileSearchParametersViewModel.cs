using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels
{
    public class FileSearchParametersViewModel : ViewModelBase
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public FileTagDto FileTag { get; set; }
        public FileTypeDto FileType { get; set; }
    }
}