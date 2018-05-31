namespace Mmu.Kms.Domain
{
    public class FileContent
    {
        public FileContent(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}