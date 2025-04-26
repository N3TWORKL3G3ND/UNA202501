using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IShipperDAL : IGenericDAL<Shipper>
    {
        IEnumerable<Shipper> GetAllSP();
        Shipper GetByIdSP(int id);
        int? InsertSP(Shipper shipper);
        bool UpdateSP(Shipper shipper);
        bool DeleteSP(int id);
    }
}
