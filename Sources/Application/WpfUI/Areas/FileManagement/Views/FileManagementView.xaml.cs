using System.Windows;
using System.Windows.Controls;
using Mmu.Kms.Domain;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Views
{
    public partial class FileManagementView : UserControl, IViewMap<FileManagementViewModel>
    {
        public static readonly DependencyProperty DirectoryStructureProperty =
            DependencyProperty.Register(
                nameof(DirectoryStructure),
                typeof(DirectoryStructure),
                typeof(FileManagementView),
                new PropertyMetadata(DirectoryStructureChanged));

        public FileManagementView()
        {
            InitializeComponent();
        }

        public DirectoryStructure DirectoryStructure
        {
            get => (DirectoryStructure)GetValue(DirectoryStructureProperty);
            set => SetValue(DirectoryStructureProperty, value);
        }

        private static void DirectoryStructureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (FileManagementView)d;
            var viewModel = (FileManagementViewModel)view.DataContext;
            viewModel.DirectoryStructure = (DirectoryStructure)e.NewValue;
        }
    }
}