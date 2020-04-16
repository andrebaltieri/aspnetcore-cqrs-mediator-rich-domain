using System.Threading.Tasks;
using Shop.Domain.Backoffice.Entities;

namespace Shop.Domain.Backoffice.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> Exists(string email);
        Task Save(Customer customer);
    }
}