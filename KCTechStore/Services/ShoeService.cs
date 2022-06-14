using KCTechStore.Models;
using KCTechStore.Repositories;

namespace KCTechStore.Services
{
    public interface IShoeService
    {
        public IEnumerable<ShoeViewModel> ShoeList();
    }

    public class ShoeService : IShoeService
    {
        public readonly IShoeRepository _shoeRepository;

        public ShoeService(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public IEnumerable<ShoeViewModel> ShoeList()
        {
            var shoes =_shoeRepository.GetShoes();

            return shoes;
        }
    }
}
