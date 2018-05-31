using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Kms.DomainServices.DataAccess.Areas.Dtos;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Services
{
    public interface IShadowFileService
    {
        ShadowFileDto GetOrCreateShadowFile(string filePath);
    }
}
