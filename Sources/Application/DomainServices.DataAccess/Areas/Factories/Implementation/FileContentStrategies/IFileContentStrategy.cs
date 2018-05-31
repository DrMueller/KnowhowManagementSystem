﻿using Mmu.Kms.Domain;

namespace Mmu.Kms.DomainServices.DataAccess.Areas.Factories.Implementation.FileContentStrategies
{
    public interface IFileContentStrategy
    {
        FileType FileType { get; }

        string ReadContent(string filePath);
    }
}