using System.ComponentModel.DataAnnotations;

namespace HumanResource
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Fantasia")]
        public string TradingName { get; set; }
    }
}
