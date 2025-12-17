using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourInclusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class TourInclusionProfile : Profile
    {
        public TourInclusionProfile()
        {
            CreateMap<TourInclusion, TourInclusionDto>();
            CreateMap<CreateTourInclusionDto, TourInclusion>();
            CreateMap<UpdateTourInclusionDto, TourInclusion>();
        }
    }
}
