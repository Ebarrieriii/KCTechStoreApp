using KCTechStore.Models;
using KCTechStore.Repositories;

namespace KCTechStore.Services
{
    public interface IComputerService
    {
        public IEnumerable<ShoeViewModel> GetComputers();
        public void PostComputers(ShoeViewModel shoeData);
    }

    public class ComputerService : IComputerService
    {
        public readonly IComputerRepository _computerRepository;

        public ComputerService(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        //GET
        public IEnumerable<ShoeViewModel> GetComputers()
        {
            var shoes = _computerRepository.GetComputers();

            return shoes;
        }

        //POST
        public void PostComputers(ShoeViewModel shoeData)
        {

            _computerRepository.PostComputers(shoeData);
        }
    }
}
