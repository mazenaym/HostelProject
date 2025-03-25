using StudentHostel.BLL.Repo.IRepo;
using StudentHostel.DAL.Database;
using StudentHostel.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.BLL.Repo
{
    public class ApartmentRepo : IApartmentRepo
    {
        private readonly ApplicationDbContext _context;
        public ApartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        //add Apartment 
        public void AddApartment(Apartment apartment)
        {
            _context.apartments.Add(apartment);
            _context.SaveChanges();
        }
        // get all apartments
        public IEnumerable<Apartment> GetAllApartment()
        {
            return _context.apartments.ToList();
        }
        //GET apartment bi id
        public Apartment GetApartmentById(int id)
        {
            return _context.apartments.FirstOrDefault(a => a.Apartment_Id == id);
        }
        public void UpdateApartment(Apartment apartment)
        {
            var existingApartment = _context.apartments.Find(apartment.Apartment_Id);
            if (existingApartment != null)
            {
                existingApartment.Price = apartment.Price != 0 ? apartment.Price : existingApartment.Price;
                existingApartment.IsRented = apartment.IsRented;

                existingApartment.Title = !string.IsNullOrEmpty(apartment.Title) ? apartment.Title : existingApartment.Title;
                existingApartment.Address = !string.IsNullOrEmpty(apartment.Address) ? apartment.Address : existingApartment.Address;
                existingApartment.Description = !string.IsNullOrEmpty(apartment.Description) ? apartment.Description : existingApartment.Description;

                existingApartment.Num_Bed = apartment.Num_Bed != 0 ? apartment.Num_Bed : existingApartment.Num_Bed;
                existingApartment.Num_Room = apartment.Num_Room != 0 ? apartment.Num_Room : existingApartment.Num_Room;
                existingApartment.FloorNum = apartment.FloorNum != 0 ? apartment.FloorNum : existingApartment.FloorNum;

                existingApartment.OwnerId = !string.IsNullOrEmpty(apartment.OwnerId) ? apartment.OwnerId : existingApartment.OwnerId;
                existingApartment.Apartment_Image = apartment.Apartment_Image ?? existingApartment.Apartment_Image;

                _context.SaveChanges();
            }
        }
        public void DeleteApartmentByOwnerId(Guid id)
        {
            string stringId = id.ToString();
            var apartments = _context.apartments.Where(a => a.OwnerId == stringId).ToList();
            if (apartments.Any())
            {
                _context.apartments.RemoveRange(apartments);
                _context.SaveChanges();
            }
        }

        // Delete a apartment by id
        public void DeleteApartment(int id)
        {
            var apartment = _context.apartments.Find(id);
            if (apartment != null)
            {
                _context.apartments.Remove(apartment);
                _context.SaveChanges();
            }
        }
    }
}

