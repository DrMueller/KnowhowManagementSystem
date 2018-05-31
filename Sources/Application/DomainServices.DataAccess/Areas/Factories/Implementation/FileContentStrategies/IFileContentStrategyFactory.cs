using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Factories.Implementation.FileContentStrategies
{
    public interface IFileContentStrategyFactory
    {
        IFileContentStrategy Create(FileType fileType);
    }
}
