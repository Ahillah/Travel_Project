using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ServiceImplementation.Hotel___Accommodation
{
    //public class RoomService : IRoomService
    //{
    //    private readonly IRoomRepository roomRepository;
    //    private readonly IMapper _mapper;

    //    public RoomService(IRoomRepository roomRepository, IMapper mapper)
    //    {
    //        roomRepository = roomRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<RoomDto> AddAsync(RoomDto dto)
    //    {
    //        var room = _mapper.Map<Room>(dto);
    //        var created = await roomRepository.AddAsync(room);
    //        return _mapper.Map<RoomDto>(created);
    //    }

    //    public async Task<bool> DeleteAsync(int id)
    //    {
    //        var existingAmenity = await roomRepository.GetByIdAsync(id);
    //        if (existingAmenity == null)
    //        {
    //            return false;
    //        }
    //        await roomRepository.DeleteAsync(id);

    //        return await roomRepository.SaveChangesAsync();
    //    }

    //    public async Task<IEnumerable<RoomDto>> GetAllAsync()
    //    {
    //        var rooms = await roomRepository.GetAllAsync();

    //        return _mapper.Map<IEnumerable<RoomDto>>(rooms);
    //    }

    //    public async Task<IEnumerable<RoomDto>> GetByHotelAsync(int hotelId)
    //    {
    //        return _mapper.Map<IEnumerable<RoomDto>>(await roomRepository.GetAllByHotelAsync(hotelId));

    //    }

    //    public async Task<RoomDto> GetByIdAsync(int Id)
    //    {
    //        var r = await roomRepository.GetByIdAsync(Id);
    //        if (r == null) return null;

    //        return _mapper.Map<RoomDto>(r);
    //    }

    //    public async Task<bool> SaveChangesAsync()
    //    {
    //        return await roomRepository.SaveChangesAsync();
    //    }

    //    public async Task<bool> UpdateAsync(UpdateRoomDto dto, int id)
    //    {
    //        var r = await roomRepository.GetByIdAsync(id);
    //        if (r == null) return false;

    //        _mapper.Map(dto, r);
    //        return await roomRepository.UpdateAsync(r);

    //    }


    //}
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto> AddAsync(RoomDto dto)
        {
            var room = _mapper.Map<Room>(dto);
            var created = await _roomRepository.AddAsync(room);
            return _mapper.Map<RoomDto>(created);
        }

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var existing = await _roomRepository.GetByIdAsync(id);
        //    if (existing == null) return false;

        //    await _roomRepository.DeleteAsync(id);
        //    return await _roomRepository.SaveChangesAsync();
        //}
        public async Task<bool> DeleteAsync(int id)
        {
            return await _roomRepository.DeleteAsync(id);
        }


        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<IEnumerable<RoomDto>> GetByHotelAsync(int hotelId)
        {
            var rooms = await _roomRepository.GetAllByHotelAsync(hotelId);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return room == null ? null : _mapper.Map<RoomDto>(room);
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto, int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return false;

            _mapper.Map(dto, room);
            return await _roomRepository.UpdateAsync(room);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _roomRepository.SaveChangesAsync();
        }
    }

}
