using Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileOverview.Views
{
    public partial class FilesOverviewView : IViewMap<FilesOverviewViewModel>
    {
        public FilesOverviewView()
        {
            InitializeComponent();
        }
    }
}