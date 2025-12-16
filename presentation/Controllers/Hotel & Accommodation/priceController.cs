using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;

namespace presentation.Controllers.Hotel___Accommodation
{
    [ApiController]
    [Route("api/price")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceAndAvailbilityService _service;

        public PricesController(IPriceAndAvailbilityService service)
        {
            _service = service;
        }

        // GET: api/price/room/5
        [HttpGet("room/{roomId:int}")]
        public async Task<IActionResult> GetByRoom(int roomId)
        {
            var result = await _service.GetByRoom(roomId);
            return Ok(result);
        }

        // GET: api/price/5/2025-01-10
        [HttpGet("get/{roomId:int}/{date}")]
        public async Task<IActionResult> Get(int roomId, DateTime date)
        {
            var p = await _service.GetByIdAsync(roomId, date.Date);
            if (p == null)
                return NotFound();

            return Ok(p);
        }

        // POST: api/price/create
        [HttpPost("create")]
        [Consumes("application/json")]
        public async Task<IActionResult> Create([FromBody] PriceAndAvailabilityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get),
                new { roomId = created.RoomId, date = created.Date.ToString("yyyy-MM-dd") },
                created);
        }

        // PUT: api/price/update/5/2025-01-10
        [HttpPut("update/{roomId:int}/{date}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Update(int roomId, DateTime date, [FromBody] PriceAndAvailabilityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = await _service.UpdateAsync(roomId, date.Date, dto);

            if (!ok)
                return NotFound(new { message = "Room not updated or not found" });

            return Ok(new { message = "Price updated" });
        }

        // DELETE: api/price/delete/5/2025-01-10
        //[HttpDelete("delete/{roomId:int}/{date}")]
        //public async Task<IActionResult> Delete(int roomId, DateTime date)
        //{
        //    var ok = await _service.DeleteAsync(roomId, date.Date);

        //    if (!ok)
        //        return NotFound(new { message = "Room not found" });

        //    return Ok(new { message = "deleted sucessfully" });
        //}

        [HttpDelete("delete/{roomId:int}/{date}")]
        public async Task<IActionResult> Delete(int roomId, DateTime date)
        {
            var ok = await _service.DeleteAsync(roomId, date);

            if (!ok)
                return NotFound(new { message = "Room + date combination not found" });

            return Ok(new { message = "Deleted successfully" });
        }

    }
}
