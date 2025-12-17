using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class TourDateProfile : Profile
    {
        public TourDateProfile()
        {
            CreateMap<TourDate, TourDateDto>();
            CreateMap<CreateTourDateDto, TourDate>();
            CreateMap<UpdateTourDateDto, TourDate>();
        }
    }
}
