using CurrentAccounts.Core.Entity;
using System.Threading.Tasks;

namespace CurrentAccounts.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
    }
}
