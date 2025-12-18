using AutoMapper;
using DomainLayer.Models.Identity;
using DomainLayer.Models.User;
using Shared.Dto_s.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()

        {
            CreateMap<CreateReviewDto, Review>()
               .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.TargetType,
                      opt => opt.MapFrom(src => Enum.Parse<ReviewTargetType>(src.TargetType)))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Review, ReviewDto>()
                      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
