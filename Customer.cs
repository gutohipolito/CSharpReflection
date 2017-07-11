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

        [Required]
        [MaxLength(10)]
        [Display(Name = "CNPJ")]
        public string Document { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [MaxLength(11)]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

    }
}
