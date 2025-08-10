using System.ComponentModel.DataAnnotations;

namespace customer_manager.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
