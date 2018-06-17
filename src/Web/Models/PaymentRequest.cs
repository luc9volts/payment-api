using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class PaymentRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be bigger than {1}")]
        public decimal Amount { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public ClientRequest Client { get; set; }
        [Required]
        public BuyerRequest Buyer { get; set; }
        public CardRequest Card { get; set; }
    }
}
