using System.ComponentModel.DataAnnotations;

namespace WebKursachAPI.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailUser { get; set; }

        [Required]
        public int IdProduct { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

