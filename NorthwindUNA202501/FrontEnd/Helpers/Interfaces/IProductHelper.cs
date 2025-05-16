using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductHelper
    {
        ProductViewModel Get(int id);

        string Token { get; set; }
        List<ProductViewModel> GetProducts();

        void Add(ProductViewModel product);
        void Update(ProductViewModel product);
        void Delete(int id);


    }
}
