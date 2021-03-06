﻿using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.FileManagement.Dtos.Profiles
{
    public class DirectoryDtoProfile : Profile
    {
        public DirectoryDtoProfile()
        {
            CreateMap<Directory, DirectoryDto>()
                .ForMember(d => d.DirectoryName, c => c.MapFrom(f => f.DirectoryName))
                .ForMember(d => d.Files, c => c.MapFrom(f => f.DirectoryName))
                .ForMember(d => d.Path, c => c.MapFrom(f => f.DirectoryName))
                .ForMember(d => d.SubDirectories, c => c.MapFrom(f => f.DirectoryName));
        }
    }
}