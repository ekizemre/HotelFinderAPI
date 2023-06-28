using HotelFinder.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
     public interface IHotelRepository
    {
       Task <List<Hotel>> GetAll();   

       Task <Hotel> GetById(int id);

        Task<Hotel> GetByName(string Name);
        Task<Hotel> GetHotelByIdAndName (int id, string Name);
        Task<Hotel> Add(Hotel hotel);

        Task<Hotel> Update(Hotel hotel);

        Task Delete(int id);
        
    }
}
