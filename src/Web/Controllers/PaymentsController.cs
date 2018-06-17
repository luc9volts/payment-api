using ApplicationCore.Abstract;
using Microsoft.AspNetCore.Mvc;
using web.Filters;
using web.Models;

namespace web.Controllers
{
    [Route("api/v1/[controller]")]
    [ValidateRequestAttribute]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentFactory _paymentFactory;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentFactory paymentFactory, IPaymentRepository paymentRepository)
        {
            _paymentFactory = paymentFactory;
            _paymentRepository = paymentRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]PaymentRequest payReq)
        {
            var payment = _paymentFactory.Create(payReq.Client.Id
                , payReq.Type, payReq.Amount
                , payReq.Buyer.Name, payReq.Buyer.Email, payReq.Buyer.Cpf
                , payReq.Card?.ExpirationDate, payReq.Card?.Cvv, payReq.Card?.HolderName, payReq.Card?.Number);

            var result = payment.Process();
            _paymentRepository.Add(payment);

            return CreatedAtRoute("GetPayment", new { id = payment.Id }, result);
        }

        [HttpGet("{id}", Name = "GetPayment")]
        public IActionResult Get(int id)
        {
            var result = _paymentRepository.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _paymentRepository.GetAll();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
