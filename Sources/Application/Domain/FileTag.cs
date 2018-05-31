using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Kms.Domain
{
    public class FileTag : AggregateRoot
    {
        public FileTag(string id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public string Description { get; }
        public string Name { get; }
    }
}