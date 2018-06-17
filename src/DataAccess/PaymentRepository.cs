using ApplicationCore.Abstract;
using LiteDB;
using System.Collections.Generic;

namespace DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        private const string dbName = "payments.db";
        private const string collName = "Payments";

        public void Add(Payment payment)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<Payment>(collName);
                col.Insert(payment);
            }
        }

        public Payment GetById(int Id)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<Payment>(collName);
                return col.FindById(Id);
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<Payment>(collName);
                return col.FindAll();
            }
        }
    }
}
