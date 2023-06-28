using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelService : IHotelService
    {
       private IHotelRepository hotelRepository;

        public HotelService(IHotelRepository hotelRepository2)
        {
            hotelRepository = hotelRepository2;
        }

        public async Task<Hotel> Add(Hotel hotel)
        {
            return await hotelRepository.Add(hotel);  
        }

        public async Task Delete(int id)
        {
           await hotelRepository.Delete(id);
        }

        public async Task <List<Hotel>> GetAll()
        {
           return await hotelRepository.GetAll(); 
        }

        public async Task <Hotel> GetById(int id)
        {
            return await hotelRepository.GetById(id); 
        }

        public async Task<Hotel> GetByName(string name)
        {
            return await hotelRepository.GetByName(name);
        }

        public async Task<Hotel> GetHotelByIdAndName(int id, string name)
        {
            return await hotelRepository.GetHotelByIdAndName(id, name);
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            return await hotelRepository.Update(hotel);       
        }
    }
}
