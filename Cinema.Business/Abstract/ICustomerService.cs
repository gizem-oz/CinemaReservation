using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IList<Customer>> CustomerAllByStatus(bool value);
        Task<Customer> GetCustomerById(int id);
        Task<IList<Customer>> GetCustomerList();
        Task Add(Customer product);
        Task AddRange(List<Customer> productList);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}
