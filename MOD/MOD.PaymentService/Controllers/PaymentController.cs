using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.PaymentService.Models;
using MOD.PaymentService.Repository;

namespace MOD.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        // GET: api/Payment
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_paymentsRepository.GetAllPayments());
        }

        // GET: api/Payment/5
        [HttpGet("{id:long:min(1)}")]
        public ActionResult<string> Get(int id)
        {
            var payment = _paymentsRepository.GetPaymentById(id);
            if(payment == null)
            {
                return NoContent();
            }
            return Ok(payment);
        }

        [HttpGet("User/{id:long:min(1)}")]
        public ActionResult<string> GetPaymentsByUser(long id)
        {
            var paymentDetails = _paymentsRepository.GetPaymentsByUser(id);
            if (paymentDetails != null && paymentDetails.Count > 0)
            {
                return Ok(paymentDetails);
            }
            return NoContent();
        }

        [HttpGet("Mentor/{id:long:min(1)}")]
        public ActionResult<string> GetPaymentsForMentor(long id)
        {
            var paymentDetails = _paymentsRepository.GetPaymentsForMentor(id);
            if (paymentDetails != null && paymentDetails.Count > 0)
            {
                return Ok(paymentDetails);
            }
            return NoContent();
        }

        // POST: api/Payment
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            _paymentsRepository.AddPayment(payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Payment payment)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            var status = _paymentsRepository.DeletePayment(id);
            if (status)
                return Ok();
            return NoContent();
        }
    }
}
