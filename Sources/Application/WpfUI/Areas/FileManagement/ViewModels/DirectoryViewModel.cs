using System.Collections.Generic;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class DirectoryViewModel : ViewModelBase
    {
        public DirectoryViewModel(string directoryName, string iconPath)
        {
            DirectoryName = directoryName;
            IconPath = iconPath;
            Files = new List<FileViewModel>();
            SubDirectories = new List<DirectoryViewModel>();
        }

        public string DirectoryName { get; }
        public List<FileViewModel> Files { get; set; }
        public string IconPath { get; }
        public List<DirectoryViewModel> SubDirectories { get; set; }
    }
}