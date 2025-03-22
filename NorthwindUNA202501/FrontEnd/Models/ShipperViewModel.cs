using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ShipperViewModel
    {
        [Display(Name = "Identificador")]
        public int ShipperId { get; set; }

        [Display(Name = "Nombre de la compannia")]
        public string CompanyName { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }
    }
}
