using Mmu.Kms.Domain;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileSearchParametersViewModel : ViewModelBase
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public FileTag FileTag { get; set; }
        public FileType FileType { get; set; }
    }
}