using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.UserControls.FileSearch
{
    public partial class FileSearch
    {
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register(
                nameof(SearchCommand),
                typeof(ICommand),
                typeof(FileSearch));
        public static readonly DependencyProperty FileTagsProperty =
            DependencyProperty.Register(
                nameof(FileTags),
                typeof(IReadOnlyCollection<FileTagDto>),
                typeof(FileSearch));
        public static readonly DependencyProperty FileTypesProperty =
            DependencyProperty.Register(
                nameof(FileTypes),
                typeof(IReadOnlyCollection<FileTypeDto>),
                typeof(FileSearch));

        public FileSearch()
        {
            SelectedRootPath = @"C:\Users\matthias.mueller\Desktop\Stuff\DropboxBackupTest";
            InitializeComponent();
        }

        public ViewModelCommand Clear
        {
            get
            {
                return new ViewModelCommand(
                    "Clear",
                    new RelayCommand(
                        () =>
                        {
                            SelectedFileContent = string.Empty;
                            SelectedFileName = string.Empty;
                            SelectedFileTag = null;
                            SelectedFileType = null;
                        }));
            }
        }

        public IReadOnlyCollection<FileTagDto> FileTags
        {
            get => (IReadOnlyCollection<FileTagDto>)GetValue(FileTagsProperty);
            set => SetValue(FileTagsProperty, value);
        }

        public IReadOnlyCollection<FileTypeDto> FileTypes
        {
            get => (IReadOnlyCollection<FileTypeDto>)GetValue(FileTypesProperty);
            set => SetValue(FileTypesProperty, value);
        }

        public ViewModelCommand Search
        {
            get
            {
                return new ViewModelCommand(
                    "Search",
                    new RelayCommand(
                        () =>
                        {
                            var fileSearchParameters = new FileSearchParametersDto
                            {
                                FileContent = SelectedFileContent,
                                FileName = SelectedFileName,
                                FileTag = SelectedFileTag,
                                FileType = SelectedFileType,
                                RootPath = SelectedRootPath
                            };

                            SearchCommand.Execute(fileSearchParameters);
                        }));
            }
        }

        public ICommand SearchCommand
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        public string SelectedFileContent { get; set; }
        public string SelectedFileName { get; set; }
        public FileTagDto SelectedFileTag { get; set; }
        public FileTypeDto SelectedFileType { get; set; }
        public string SelectedRootPath { get; set; }
    }
}