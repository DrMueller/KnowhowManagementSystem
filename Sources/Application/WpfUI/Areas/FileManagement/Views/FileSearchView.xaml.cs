using System;
using System.Windows;
using System.Windows.Controls;
using Mmu.Kms.Domain;
using Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.Views
{
    public partial class FileSearchView : UserControl, IViewMap<FileSearchViewModel>
    {
        public static readonly DependencyProperty SearchCallbackProperty =
            DependencyProperty.Register(
                nameof(SearchCallback),
                typeof(Action<FileSearchParameters>),
                typeof(FileSearchView),
                new PropertyMetadata(SearchCallbackChanged));

        public FileSearchView()
        {
            InitializeComponent();
        }

        public Action<FileSearchParameters> SearchCallback
        {
            get => (Action<FileSearchParameters>)GetValue(SearchCallbackProperty);
            set => SetValue(SearchCallbackProperty, value);
        }

        private static void SearchCallbackChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (FileSearchView)d;
            var viewModel = (FileSearchViewModel)view.DataContext;
            viewModel.SearchCallback = (Action<FileSearchParameters>)e.NewValue;
        }
    }
}