using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ShipperDALImpl: GenericDALImpl<Shipper>, IShipperDAL
    {
        NorthWindContext _context;
        public ShipperDALImpl(NorthWindContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Shipper> GetAllSP()
        {
            return _context.Shippers
                .FromSqlRaw("EXEC sp_GetAllShippers")
                .ToList();
        }

        public Shipper GetByIdSP(int id)
        {
            return _context.Shippers
                .FromSqlRaw("EXEC sp_GetShipperById @ShipperID = {0}", id)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public int? InsertSP(Shipper shipper)
        {
            // SP devuelve SCOPE_IDENTITY, lo capturamos con una variable temporal
            var newId = _context.Shippers
                .FromSqlRaw("EXEC sp_InsertShipper @CompanyName = {0}, @Phone = {1}",
                    shipper.CompanyName,
                    shipper.Phone ?? (object)DBNull.Value)
                .AsEnumerable()
                .Select(s => s.ShipperId)
                .FirstOrDefault(); // Se espera que solo devuelva el insertado

            return newId;
        }

        public bool UpdateSP(Shipper shipper)
        {
            var affected = _context.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateShipper @ShipperID = {0}, @CompanyName = {1}, @Phone = {2}",
                shipper.ShipperId,
                shipper.CompanyName,
                shipper.Phone ?? (object)DBNull.Value);

            return affected > 0;
        }

        public bool DeleteSP(int id)
        {
            var affected = _context.Database.ExecuteSqlRaw(
                "EXEC sp_DeleteShipper @ShipperID = {0}", id);

            return affected > 0;
        }

    }
}
