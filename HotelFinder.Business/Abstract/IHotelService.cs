using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {

        Task<List<Hotel>> GetAll();
        Task<Hotel> GetById(int id);
        Task<Hotel> GetByName(string name);
        Task<Hotel> GetHotelByIdAndName(int id, string name);
        Task<Hotel> Add(Hotel hotel);
        Task<Hotel> Update(Hotel hotel);
        Task Delete(int id);
    }
}
