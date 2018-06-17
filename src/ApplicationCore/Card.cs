using System;

namespace ApplicationCore
{
    public class Card
    {
        public string HolderName { get; set; }
        public string Number { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Cvv { get; set; }
        public bool Status;
    }
}
