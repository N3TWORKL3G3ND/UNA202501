using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public ICategoryDAL CategoryDAL { get; set; }
        public IShipperDAL ShipperDAL { get; set; }

        public IProductDAL ProductDAL { get; set; }
        public ISupplierDAL SupplierDAL { get; set; }

        public IOrderDAL OrderDAL { get; set; }

        NorthWindContext context;

        public UnidadDeTrabajo(ICategoryDAL categoryDAL, NorthWindContext context
            , IShipperDAL shipperDAL
            ,IProductDAL productDAL
            ,ISupplierDAL supplierDAL
            ,IOrderDAL orderDAL)
        {
            CategoryDAL = categoryDAL;
            this.context = context;
            ShipperDAL = shipperDAL;
            ProductDAL = productDAL;
            SupplierDAL = supplierDAL;
            OrderDAL = orderDAL;
        }
        public void Dispose()
        {
            this.context.Dispose();
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
