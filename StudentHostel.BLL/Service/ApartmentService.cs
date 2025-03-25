using StudentHostel.BLL.Repo.IRepo;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Service
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepo _apartmentrepository;
        public ApartmentService(IApartmentRepo apartmentRepository)
        {
            _apartmentrepository = apartmentRepository;
        }
        public void AddApartment(Apartment apartment)
        {
            _apartmentrepository.AddApartment(apartment);
        }
        public IEnumerable<Apartment> GetAllApartment()
        {
            return _apartmentrepository.GetAllApartment();
        }
        public Apartment GetApartmentById(int id)
        {
            return _apartmentrepository.GetApartmentById(id);
        }
        public void UpdateApartment(Apartment apartment)
        {
            _apartmentrepository.UpdateApartment(apartment);
        }
        public void DeleteApartmentByOwnerId(Guid id)
        {
            _apartmentrepository.DeleteApartmentByOwnerId(id);
        }
        public void DeleteApartment(int id)
        {
            _apartmentrepository.DeleteApartment(id);
        }
    }
}
