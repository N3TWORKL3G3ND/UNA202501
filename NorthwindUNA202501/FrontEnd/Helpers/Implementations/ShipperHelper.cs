using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

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

        ShipperAPI Convertir(ShipperViewModel shipper)
        {
            return new ShipperAPI
            {
                ShipperId = shipper.ShipperId,

                CompanyName = shipper.CompanyName,

                Phone = shipper.Phone
            };
        }




        public ShipperViewModel Create(ShipperViewModel shipper)
        {
            var response = _helper.Post("api/Shipper", Convertir(shipper));

            return shipper;
        }



        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ShipperViewModel Get(int id)
        {
            var response = _helper.GetResponseMessage("api/Shipper/" + id.ToString());
            var shipper = new ShipperViewModel();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<ShipperAPI>(content);

                shipper = Convertir(result);


            }
            return shipper;
        }

        public List<ShipperViewModel> GetShippers()
        {
            var response = _helper.GetResponseMessage("api/Shipper");
            var lista = new List<ShipperViewModel>();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var shippers = JsonConvert.DeserializeObject<List<ShipperAPI>>(content);



                foreach (var item in shippers)
                {
                    lista.Add(Convertir(item));

                }
            }
            return lista;
        }

        public ShipperViewModel Update(ShipperViewModel shipper)
        {
            var response = _helper.Put("api/Shipper", Convertir(shipper));

            return shipper;
        }
    }
}
