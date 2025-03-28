using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public CustomerService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        CustomerDTO Convertir(Customer customer)
        {
            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName
            };
        }

        Customer Convertir(CustomerDTO customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName
            };
        }


        public CustomerDTO AddCustomer(CustomerDTO customer)
        {
            _unidadDeTrabajo.CustomerDAL.Add(Convertir(customer));
            _unidadDeTrabajo.Complete();
            return customer;
        }

        public CustomerDTO DeleteCustomer(string id)
        {
            var Customer = new Customer { CustomerId = id };
            _unidadDeTrabajo.CustomerDAL.Remove(Customer);
            _unidadDeTrabajo.Complete();
            return Convertir(Customer);
        }

        public CustomerDTO GetCustomerById(string id)
        {
            var result = _unidadDeTrabajo.CustomerDAL.FindByIdString(id);
            return Convertir(result);
        }

        public List<CustomerDTO> GetCustomers()
        {
            var customers = _unidadDeTrabajo.CustomerDAL.Get();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                customerDTOs.Add(this.Convertir(customer));
            }
            return customerDTOs;
        }

        public CustomerDTO UpdateCustomer(CustomerDTO customer)
        {
            var entity = Convertir(customer);
            _unidadDeTrabajo.CustomerDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return customer;
        }

    }
}
