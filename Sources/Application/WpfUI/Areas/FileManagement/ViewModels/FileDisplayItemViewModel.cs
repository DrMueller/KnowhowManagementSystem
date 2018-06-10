using System.Collections.Generic;
using System.Linq;

namespace Mmu.Kms.WpfUI.Areas.FileManagement.ViewModels
{
    public class FileDisplayItemViewModel
    {
        private readonly IReadOnlyCollection<string> _fileTagNames;

        public FileDisplayItemViewModel(string fileName, string icon, IReadOnlyCollection<string> fileTagNames)
        {
            _fileTagNames = fileTagNames;
            FileName = fileName;
            Icon = icon;
        }

        public string FileName { get; }

        public string FileTagsDescription
        {
            get
            {
                if (!_fileTagNames.Any())
                {
                    return string.Empty;
                }

                return "- " + string.Join(", ", _fileTagNames);
            }
        }

        public string Icon { get; }
    }
}