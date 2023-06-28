using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{

    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _repository;

        public HotelRepository(HotelDbContext repository)
        {
            _repository = repository;
        }

        public async Task<Hotel> Add(Hotel hotel)
        {
            _repository.Hotels.Add(hotel);
            await _repository.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            var hotels = _repository.Hotels.Find(id);
            _repository.Hotels.Remove(hotels);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetAll()
        {
            var hotels = await _repository.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> GetById(int id)
        {
            var hotels = await _repository.Hotels.FindAsync(id);
            return hotels;
        }

        public async Task<Hotel> GetByName(string Name)
        {
            var hotels = await _repository.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == Name.ToLower());
            //var hotels = _repository.Hotels.FirstOrDefault(x => x.Name == Name);
            return hotels;
        }

        public async Task<Hotel> GetHotelByIdAndName(int id, string Name)
        {
            var hotels = await _repository.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == Name.ToLower() && x.Id == id);
            return hotels;
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            var updatedata = await _repository.Hotels.FindAsync(hotel.Id);
            updatedata.Name = hotel.Name;
            updatedata.City = hotel.City;
            //_repository.Update(hotel);  
            await _repository.SaveChangesAsync();
            return hotel;
        }
    }
}
