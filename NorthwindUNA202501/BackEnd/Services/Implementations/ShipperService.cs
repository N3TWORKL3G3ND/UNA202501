using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public ShipperService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        ShipperDTO Convertir(Shipper shipper)
        {
            return new ShipperDTO
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }

        Shipper Convertir(ShipperDTO shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }



        public ShipperDTO AddShipper(ShipperDTO shipper)
        {
            _unidadDeTrabajo.ShipperDAL.Add(Convertir(shipper));
            _unidadDeTrabajo.Complete();
            return shipper;
        }

        public ShipperDTO DeleteShipper(int id)
        {
            var Shipper = new Shipper { ShipperId = id };
            _unidadDeTrabajo.ShipperDAL.Remove(Shipper);
            _unidadDeTrabajo.Complete();
            return Convertir(Shipper);
        }

        public ShipperDTO GetShipperById(int id)
        {
            var result = _unidadDeTrabajo.ShipperDAL.FindById(id);
            return Convertir(result);
        }

        public List<ShipperDTO> GetShippers()
        {
            var shippers = _unidadDeTrabajo.ShipperDAL.Get();
            List<ShipperDTO> shipperDTOs = new List<ShipperDTO>();
            foreach (var shipper in shippers)
            {
                shipperDTOs.Add(this.Convertir(shipper));
            }
            return shipperDTOs;
        }

        public ShipperDTO UpdateShipper(ShipperDTO shipper)
        {
            var entity = Convertir(shipper);
            _unidadDeTrabajo.ShipperDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return shipper;
        }
    }
}
