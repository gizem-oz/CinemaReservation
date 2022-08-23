using Cinema.Business.Abstract;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IList<Customer>> CustomerAllByStatus(bool value)
        {
            return await _customerDal.GetAll(x => x.Status == value);
        }
        

        public async Task Add(Customer customer)
        {
              await _customerDal.Add(customer); 
        }

        public async Task AddRange(List<Customer> customerList)
        {
            if (customerList.Count>0)
            {
                await _customerDal.AddRange(customerList);
            }
            
        }

        public async Task Delete(int id)
        {
            Customer customer = await GetCustomerById(id);
            if (customer != null)
            {
                customer.Status = false;
                await Update(customer);
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerDal.Get(x => x.AppIdentityUserId == id);
        }

        public async Task<IList<Customer>> GetCustomerList()
        {
            return await _customerDal.GetAll(x => x.Status == true);
        }

        public async Task Update(Customer customer)
        {
            await _customerDal.Update(customer);
        }
    }
}
