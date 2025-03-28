
using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetCustomers();
        CustomerDTO GetCustomerById(string id);
        CustomerDTO AddCustomer(CustomerDTO customer);
        CustomerDTO UpdateCustomer(CustomerDTO customer);
        CustomerDTO DeleteCustomer(string id);
    }
}
