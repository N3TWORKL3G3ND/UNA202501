using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {
        ShipperViewModel Get(int id);

        List<ShipperViewModel> GetShippers();

        ShipperViewModel Create(ShipperViewModel shipper);

        ShipperViewModel Update(ShipperViewModel Shipper);


        void Delete(int id);
    }
}
