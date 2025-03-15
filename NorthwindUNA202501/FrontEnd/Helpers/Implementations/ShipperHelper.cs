using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {
        IServiceHelper _helper;

        public ShipperHelper(IServiceHelper helper)
        {
            _helper = helper;
        }

        ShipperViewModel Convertir(ShipperAPI shipper)
        {
            return new ShipperViewModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        CategoryAPI Convertir(CategoryViewModel category)
        {
            return new CategoryAPI
            {
                CategoryId = category.CategoryId,

                CategoryName = category.CategoryName
            };
        }




        public ShipperViewModel Create(ShipperViewModel shipper)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ShipperViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ShipperViewModel> GetShippers()
        {
            throw new NotImplementedException();
        }

        public ShipperViewModel Update(ShipperViewModel Shipper)
        {
            throw new NotImplementedException();
        }
    }
}
