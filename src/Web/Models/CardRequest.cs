using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class CardRequest
    {
        [Required]
        public string HolderName { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime? ExpirationDate { get; set; }
        [Required]
        public int? Cvv { get; set; }
    }
}
