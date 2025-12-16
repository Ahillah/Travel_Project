using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>();
        }
    }
}
