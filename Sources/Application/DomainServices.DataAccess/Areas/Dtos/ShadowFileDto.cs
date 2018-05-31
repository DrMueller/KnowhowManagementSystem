using System.Collections.Generic;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Dtos
{
    public class ShadowFileDto
    {
        public string FilePath { get; set; }
        public IReadOnlyCollection<string> TagNames { get; set; }
    }
}