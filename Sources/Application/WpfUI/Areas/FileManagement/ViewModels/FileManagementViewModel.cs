using Mmu.Kms.Domain;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileManagementViewModel : ViewModelBase
    {
        public DirectoryStructure DirectoryStructure { get; set; }
    }
}