using System.ComponentModel.DataAnnotations;

namespace customer_manager.Models
{
    public class CustomerBinding
    {
        [Required(ErrorMessage = "is required")]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Required(ErrorMessage ="is required")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [Required(ErrorMessage = "is required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "is required")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "is required")]
        [Display(Name = "City")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "is required")]
        [Display(Name = "State")]
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
