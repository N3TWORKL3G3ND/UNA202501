using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CustomerDALImpl : GenericDALImpl<Customer>, ICustomerDAL
    {
        NorthWindContext _context;

        public CustomerDALImpl(NorthWindContext context) : base(context)
        {
            _context = context;
        }
    }
}
