using System.Collections.Generic;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.FileManagement.Dtos
{
    public class ShadowFileDto
    {
        public IReadOnlyCollection<string> TagNames { get; set; }

        public static ShadowFileDto CreateEmpty(string filePath) =>
            new ShadowFileDto
            {
                TagNames = new List<string>()
            };
    }
}