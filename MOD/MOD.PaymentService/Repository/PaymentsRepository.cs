using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.PaymentService.DBContexts;
using MOD.PaymentService.Models;

namespace MOD.PaymentService.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentsContext _paymentsContext;

        public PaymentsRepository(PaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;
        }

        public void Save()
        {
            _paymentsContext.SaveChanges();
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentsContext.Payments.ToList();
        }

        public Payment GetPaymentById(long id)
        {
            var payment = _paymentsContext.Payments.Find(id);
            return payment;
        }

        public void AddPayment(Payment payment)
        {
            payment.mentorName = _paymentsContext.Mentors
                .Where(x => x.Id == payment.Id)
                .Select(y => (y.firstName + " " + y.lastName)).FirstOrDefault();
            payment.datetime = DateTime.Now;
            payment.remarks = "OPEN";
            _paymentsContext.Payments.Add(payment);
            Save();
        }

        public bool DeletePayment(long id)
        {
            var payment = _paymentsContext.Payments.Find(id);
            if(payment != null)
            {
                _paymentsContext.Payments.Remove(payment);
                Save();
                return true;
            }
            return false;
        }

        public List<Payment> GetPaymentsByUser(long id)
        {
            //var Payments = _paymentsContext.Trainings.Where(x => x.userId == id)
            //    .Select(y => y.Id).ToList();

            var payments = _paymentsContext.Payments
                .Where(x => x.Training.userId == id).ToList();
            return payments;
        }

        public List<Payment> GetPaymentsForMentor(long id)
        {
            return _paymentsContext.Payments
                .Where(x => x.mentorId == id).ToList();
        }

        public void UpdatePayment(Payment payment)
        {
            var paymentDetail = _paymentsContext.Payments.Find(payment.Id);
            if(paymentDetail != null)
            {
                paymentDetail.remarks = "TAKEN";
                Save();
            }
        }
    }
}
