//using AutoMapper;
//using DomainLayer.Models.Hotels___Accommodation;
//using DomainLayer.RepositoryInterface.Hotel___Accommodation;
//using ServiceAbstraction.Hotel___Accommodation;
//using Shared.Dto_s.Hotel___Accommodation;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ServiceImplementation.Hotel___Accommodation
//{
//    public class HotelAmenityService : IHotelAmenityService
//    {
//        private readonly IHotelAmenityRepository _hotelAmenityRepo;
//        private readonly IMapper _mapper;

//        public HotelAmenityService(IHotelAmenityRepository hotelAmenityRepo, IMapper mapper)
//        {
//            _hotelAmenityRepo = hotelAmenityRepo;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<HotelAmenityDto>> GetByHotelAsync(int hotelId)
//        {
//            var data = await _hotelAmenityRepo.GetByHotelAsync(hotelId);
//            return _mapper.Map<IEnumerable<HotelAmenityDto>>(data);
//        }

//        public async Task<HotelAmenityDto> AddAsync(HotelAmenityDto dto)
//        {
//            var entity = _mapper.Map<HotelAmenity>(dto);
//            var created = await _hotelAmenityRepo.AddAsync(entity);
//            return _mapper.Map<HotelAmenityDto>(created);
//        }

//        public async Task<bool> DeleteAsync(int hotelId, int amenityId)
//        {
//            var exists = await _hotelAmenityRepo.GetByIdAsync(hotelId, amenityId);
//            if (exists == null)
//                return false;

//            await _hotelAmenityRepo.DeleteAsync(hotelId, amenityId);
//            return await _hotelAmenityRepo.SaveAsync();
//        }

//        public async Task<HotelAmenityDto> GetByIdAsync(int hotelId, int amenityId)
//        {
//            var entity = await _hotelAmenityRepo.GetByIdAsync(hotelId, amenityId);
//            return _mapper.Map<HotelAmenityDto>(entity);
//        }

//        public async Task<IEnumerable<HotelAmenityDto>> GetAllAsync()
//        {
//            var data = await _hotelAmenityRepo.GetAllAsync();
//            return _mapper.Map<IEnumerable<HotelAmenityDto>>(data);
//        }


//    }
//}

using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceImplementation.Hotel___Accommodation
{
    public class HotelAmenityService : IHotelAmenityService
    {
        private readonly IHotelAmenityRepository _repo;
        private readonly IMapper _mapper;

        public HotelAmenityService(IHotelAmenityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Get all hotel amenities
        public async Task<IEnumerable<HotelAmenityDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<HotelAmenityDto>>(data);
        }

        // Get by composite key
        public async Task<HotelAmenityDto> GetByIdAsync(int hotelId, int amenityId)
        {
            var entity = await _repo.GetByIdAsync(hotelId, amenityId);
            if (entity == null) return null;
            return _mapper.Map<HotelAmenityDto>(entity);
        }

        // Get all amenities for a hotel
        public async Task<IEnumerable<HotelAmenityDto>> GetByHotelAsync(int hotelId)
        {
            var data = await _repo.GetByHotelAsync(hotelId);
            return _mapper.Map<IEnumerable<HotelAmenityDto>>(data);
        }

        // Add new HotelAmenity
        public async Task<HotelAmenityDto> AddAsync(HotelAmenityDto dto)
        {
            var entity = _mapper.Map<HotelAmenity>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<HotelAmenityDto>(created);
        }

        // Delete HotelAmenity
        public async Task<bool> DeleteAsync(int hotelId, int amenityId)
        {
            var exists = await _repo.GetByIdAsync(hotelId, amenityId);
            if (exists == null) return false;

            await _repo.DeleteAsync(hotelId, amenityId);
            return await _repo.SaveAsync();
        }
    }
}

