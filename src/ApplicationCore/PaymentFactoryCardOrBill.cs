using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Abstract;

namespace ApplicationCore
{
    public class PaymentFactoryCardOrBill : IPaymentFactory
    {
        private enum PaymentType
        {
            CREDIT_CARD,
            BOLETO
        }

        /// <summary>
        /// What type of payment will be created
        /// </summary>
        public Payment Create(int clienId, string paymentType, decimal paymentAmount, string buyerName, string buyerEmail, string buyerCpf, DateTime? cardExpirationDate, int? cardCvv, string cardHolderName, string cardNumber)
        {
            if (paymentType.ToUpper() == PaymentType.CREDIT_CARD.ToString())
            {
                var someDataCardIsNull = (new List<object> { cardHolderName, cardNumber, cardExpirationDate, cardCvv })
                    .Any(o => o == null);

                if (someDataCardIsNull || (cardHolderName.Trim() == string.Empty || cardNumber.Trim() == string.Empty))
                    throw new ArgumentException(@"Credit card data wasn't informed");

                return new CardPayment
                {
                    Amount = paymentAmount,
                    Type = paymentType,
                    Buyer = new Buyer { Cpf = buyerCpf, Email = buyerEmail, Name = buyerName },
                    Client = new Client { Id = clienId },
                    Card = new Card { Number = cardNumber, HolderName = cardHolderName, ExpirationDate = cardExpirationDate, Cvv = cardCvv }
                };
            }

            else if (paymentType.ToUpper() == PaymentType.BOLETO.ToString())
                return new BilletPayment
                {
                    Amount = paymentAmount,
                    Type = paymentType,
                    Buyer = new Buyer { Cpf = buyerCpf, Email = buyerEmail, Name = buyerName },
                    Client = new Client { Id = clienId }
                };
            else
                throw new ArgumentException($"{paymentType} is not a valid payment type. Use 'CREDIT_CARD' or 'BOLETO'");
        }
    }
}
