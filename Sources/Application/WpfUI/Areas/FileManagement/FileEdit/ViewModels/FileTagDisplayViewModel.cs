using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Mmu.Kms.Application.Areas.Domain.Common.Dtos;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.FileEdit.ViewModels
{
    public class FileTagDisplayViewModel : ViewModelBase
    {
        private ObservableCollection<FileTagDto> _fileTags;

        public FileTagDisplayViewModel()
        {
            FileTagViewModels = new ObservableCollection<FileTagViewModel>();
        }

        public ObservableCollection<FileTagDto> FileTags
        {
            get => _fileTags;
            set
            {
                _fileTags = value;
                _fileTags.CollectionChanged += FileTags_CollectionChanged;
                AlignViewModels();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileTagViewModel> FileTagViewModels { get; }

        private void AlignViewModels()
        {
            var itemsToRemove = FileTagViewModels.Where(item => FileTags.All(f => f.Id != item.Id)).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                FileTagViewModels.Remove(itemToRemove);
            }

            var itemsToAdd = FileTags.Where(fileTag => FileTagViewModels.All(f => f.Id != fileTag.Id)).ToList();
            foreach (var itemToAdd in itemsToAdd)
            {
                FileTagViewModels.Add(CreateVm(itemToAdd));
            }
        }

        private void FileTags_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            AlignViewModels();
        }

        private ICommand CreateRemoveFileTagCommand(FileTagDto dto) =>
            new RelayCommand(
                () =>
                {
                    FileTags.Remove(dto);
                });

        private FileTagViewModel CreateVm(FileTagDto dto)
            => new FileTagViewModel(dto.Id, dto.Name, CreateRemoveFileTagCommand(dto));
    }
}