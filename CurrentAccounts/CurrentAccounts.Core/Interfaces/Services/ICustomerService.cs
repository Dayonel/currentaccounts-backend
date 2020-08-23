using CurrentAccounts.Core.DTO;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomer(int id);
    }
}
