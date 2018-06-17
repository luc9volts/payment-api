using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class BuyerRequest
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
