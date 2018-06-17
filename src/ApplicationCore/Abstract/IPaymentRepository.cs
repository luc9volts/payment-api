using System.Collections.Generic;

namespace ApplicationCore.Abstract
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        Payment GetById(int Id);
        IEnumerable<Payment> GetAll();
    }
}
