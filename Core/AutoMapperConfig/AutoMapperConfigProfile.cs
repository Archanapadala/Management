using AutoMapper;
using Backend.Core.Dtos.Company;
using Backend.Core.Dtos.Job;
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
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


            //Candidate
        }

    }
}
