using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var hotels = await _hotelService.GetAll();
            return Ok(hotels);

        }
        /// <summary>
        /// Get Hotel By id
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        //[Route("GetHotelById/{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound("İLGİLİ HOTEL BULUNAMADI");
        }
        /// <summary>
        /// Get Hotel By name
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        //[Route("GetHotelByName/{name}")]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound("İLGİLİ HOTEL BULUNAMADI");
        }
        /// <summary>
        /// Get Hotel By name and Id
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        //[Route("GetHotelByName/{name}")]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByIdAndName(int id, string name)
        {
            var hotel = await _hotelService.GetHotelByIdAndName(id, name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound("İLGİLİ HOTEL BULUNAMADI");
        }
        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createHotel = await _hotelService.Add(hotel);
                return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);
            }
            return BadRequest(ModelState);
        }
        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetById(hotel.Id) != null)
            {
                return Ok(await _hotelService.Update(hotel));
            }
            return NotFound("hotel bulunamadı");
        }
        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetById(id) != null)
            {
                await _hotelService.Delete(id);
                return Ok("Hotel Silindi");
            }
            return NotFound("hotel bulunamadı");
        }


    }
}
