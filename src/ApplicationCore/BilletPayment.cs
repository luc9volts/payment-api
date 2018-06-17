using ApplicationCore.Abstract;
using System;
using System.Linq;

namespace ApplicationCore
{
    public class BilletPayment : Payment
    {
        private static readonly Random rnd = new Random();

        /// <summary>
        /// When the payment method is boleto, we only need to return the boleto's number in our response.        /// </summary>
        /// <returns>Boleto's number</returns>
        public override object Process()
        {
            BilletNumber = RandomBillNumber();//"...just mock the answers"
            return BilletNumber;
        }

        public static string RandomBillNumber()
        {
            const string range = "0123456789";
            const int billNumberSize = 47;

            return new string(Enumerable.Repeat(range, billNumberSize)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
