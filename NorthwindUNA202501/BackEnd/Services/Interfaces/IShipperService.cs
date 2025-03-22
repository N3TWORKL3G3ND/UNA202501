using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        List<ShipperDTO> GetShippers();
        ShipperDTO GetShipperById(int id);
        ShipperDTO AddShipper(ShipperDTO shipper);
        ShipperDTO UpdateShipper(ShipperDTO shipper);
        ShipperDTO DeleteShipper(int id);
    }
}
