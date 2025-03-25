using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Service.IService
{
    public interface IApartmentService
    {
        void AddApartment(Apartment apartment);
        void DeleteApartment(int id);
        void DeleteApartmentByOwnerId(Guid id);
        IEnumerable<Apartment> GetAllApartment();
        Apartment GetApartmentById(int id);
        void UpdateApartment(Apartment apartment);
    }
}