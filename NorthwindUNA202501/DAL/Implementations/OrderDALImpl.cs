using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class OrderDALImpl : GenericDALImpl<Order>, IOrderDAL
    {
        NorthWindContext _context;

        public OrderDALImpl(NorthWindContext context) : base(context)
        {
            _context = context;
        }
    }
}
