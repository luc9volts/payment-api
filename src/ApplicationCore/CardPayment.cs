using ApplicationCore.Abstract;
using System;

namespace ApplicationCore
{
    public class CardPayment : Payment
    {
        private static readonly Random rnd = new Random();

        /// <summary>
        /// When the method is card, we need to return if it was successful or not
        /// </summary>
        /// <returns>Boolean</returns>
        public override object Process()
        {
            Card.Status = RandomStatus();//"...just mock the answers"
            return Card.Status;
        }

        private bool RandomStatus()
        {
            return Convert.ToBoolean(rnd.Next(0, 2));
        }
    }
}
