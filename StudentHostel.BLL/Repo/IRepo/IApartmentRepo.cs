using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Repo.IRepo
{
    public interface IApartmentRepo
    {
        void AddApartment(Apartment apartment);
        void DeleteApartment(int id);
        IEnumerable<Apartment> GetAllApartment();
        Apartment GetApartmentById(int id);
        void UpdateApartment(Apartment apartment);
    }
}