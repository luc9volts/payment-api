using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class ClientRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
