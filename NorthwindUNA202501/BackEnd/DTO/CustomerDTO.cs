namespace BackEnd.DTO
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }
    }
}
