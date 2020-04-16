using System.Threading.Tasks;
using Shop.Domain.Backoffice.Entities;
using Shop.Domain.Backoffice.Repositories;

namespace Shop.Domain.Backoffice.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public Task<bool> Exists(string email)
        {
            return Task.FromResult(email == "andre@balta.io");
        }


        public Task Save(Customer customer)
        {
            return Task.FromResult(0);
        }
    }
}