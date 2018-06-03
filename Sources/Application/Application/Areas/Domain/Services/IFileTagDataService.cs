﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Kms.Application.Areas.Domain.Dtos;

namespace Mmu.Kms.Application.Areas.Domain.Services
{
    public interface IFileTagDataService
    {
        Task<IReadOnlyCollection<FileTagDto>> LoadAllAsync();

        Task<FileTagDto> LoadAsync(string id);

        Task SaveAsync(FileTagDto dto);

        Task DeleteAsync(string id);
    }
}