using System.Windows.Controls;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Views
{
    public partial class FilesOverviewView : UserControl, IViewMap<FilesOverviewViewModel>
    {
        public FilesOverviewView()
        {
            InitializeComponent();
        }
    }
}