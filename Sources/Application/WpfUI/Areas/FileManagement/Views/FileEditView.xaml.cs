using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.AppContext.Views;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Views
{
    public partial class FileEditView : IViewMap<FileEditViewModel>, IClosableView
    {
        public FileEditView()
        {
            InitializeComponent();
        }
    }
}