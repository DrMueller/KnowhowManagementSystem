using System.Collections.Generic;
using System.Linq;

namespace Mmu.Kms.Domain
{
    public class FileType
    {
        private FileType(string description, string extension)
        {
            Description = description;
            Extension = extension;
        }

        public string Description { get; }
        public string Extension { get; }
        public static FileType Markdown =>
            new FileType("Markdown", ".MD");
        public static FileType Pdf =>
            new FileType("PDF", ".PDF");
        public static FileType TextFile =>
            new FileType("Text", ".TXT");
        public static FileType Word =>
            new FileType("Word", ".DOCX");

        public static FileType Unknown =>
            new FileType("Unknown", string.Empty);

        public static FileType CreateFromExtension(string extension) =>
            All.FirstOrDefault(f => f.Extension == extension.ToUpperInvariant()) ?? Unknown;

        public static IReadOnlyCollection<FileType> All
            => new List<FileType>
            {
                Markdown,
                Pdf,
                TextFile,
                Word,
                Unknown
            };
    }
}