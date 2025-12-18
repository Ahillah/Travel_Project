using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Hotel___Accommodation
{
    public class AmenityService : IAmenityService
    {
        public readonly IAmenityRepository _amenityRepository;
        private readonly IMapper _mapper;

        public AmenityService(IAmenityRepository amenityRepository, IMapper mapper)
        {
            _amenityRepository = amenityRepository;
            _mapper = mapper;
        }

        public async Task<AmenityDto> GetByIdAsync(int id)
        {
            var a = await _amenityRepository.GetByIdAsync(id);
            if (a == null) return null;

            return _mapper.Map<AmenityDto>(a);
        }
        public async Task<IEnumerable<AmenityDto>> GetAllAsync()
        {
            var amenities = await _amenityRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AmenityDto>>(amenities);
        }
        //public async Task<bool> UpdateAsync(int id, AmenityDto dto)
        //{
        //    var entity = await _amenityRepository.GetByIdAsync(dto.Id);
        //    if (entity == null) return false;
        //    _mapper.Map(dto, entity);
        //    return await _amenityRepository.UpdateAsync(entity);

        //}
        //public async Task<bool> UpdateAsync(int id, AmenityDto dto)
        //{
        //    // Get entity using the id from the route (NOT dto.Id)
        //    var entity = await _amenityRepository.GetByIdAsync(id);

        //    if (entity == null)
        //        return false;

        //    // Map incoming data to the existing entity
        //    _mapper.Map(dto, entity);

        //    // Save to database
        //    return await _amenityRepository.UpdateAsync(entity);
        //}
        public async Task<bool> UpdateAsync(int id, AmenityDto dto)
        {
            var entity = await _amenityRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            // just update the fields MANUALLY (safest way)
            entity.Name = dto.Name;

            return await _amenityRepository.UpdateAsync(entity);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var existingAmenity = await _amenityRepository.GetByIdAsync(id);
            if (existingAmenity == null)
            {
                return false;
            }
            return await _amenityRepository.DeleteAsync(id);
        }
        //public async Task<bool> AddAsync(AmenityDto dto)
        //{
        //    var entity = new Amenity
        //    {
        //        Name = dto.Name
        //    };

        //    await _amenityRepository.AddAsync(entity);
        //    return await _amenityRepository.SaveAsync();
        //}

        public async Task<AmenityDto> CreateAsync(AmenityDto dto)
        {
            var amenity = _mapper.Map<Amenity>(dto);
            var createdAmenity = await _amenityRepository.AddAsync(amenity);
            return _mapper.Map<AmenityDto>(createdAmenity);
        }


    }
}
