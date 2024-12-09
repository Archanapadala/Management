﻿using AutoMapper;
using Backend.Core.Dtos.Company;
using Backend.Core.Entities;

namespace Backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {

        public AutoMapperConfigProfile()
        {
            //Company 

            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();

            // Job 

            //Candidate
        }

    }
}
