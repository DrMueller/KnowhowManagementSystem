﻿using AutoMapper;
using Mmu.Kms.Domain;

namespace Mmu.Kms.Application.Areas.Domain.Dtos.Profiles
{
    public class FileTagDtoProfile : Profile
    {
        public FileTagDtoProfile()
        {
            CreateMap<FileTag, FileTagDto>()
                .ForMember(d => d.Description, c => c.MapFrom(f => f.Description))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.Name, c => c.MapFrom(f => f.Name));
        }
    }
}