namespace ApplicationCore.Abstract
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public Client Client { get; set; }
        public Buyer Buyer { get; set; }
        public Card Card { get; set; }
        public string BilletNumber { get; set; }

        public abstract object Process();
    }
}
