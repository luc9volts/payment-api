using System;

namespace ApplicationCore.Abstract
{
    public interface IPaymentFactory
    {
        Payment Create(int clienId, string paymentType, decimal paymentAmount, string buyerName, string buyerEmail, string buyerCpf, DateTime? cardExpirationDate, int? cardCvv, string cardHolderName, string cardNumber);
    }
}
