using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileViewModel : ViewModelBase
    {
        public FileViewModel(string fileName, string directoryPath, string iconPath, string tagDescription)
        {
            FileName = fileName;
            DirectoryPath = directoryPath;
            IconPath = iconPath;
            TagDescription = tagDescription;
        }

        public string FileName { get; }
        public string DirectoryPath { get; }
        public string IconPath { get; }
        public string TagDescription { get; }
    }
}