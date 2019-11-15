using MOD.PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.PaymentService.Repository
{
    public interface IPaymentsRepository
    {
        List<Payment> GetAllPayments();

        Payment GetPaymentById(long id);

        void AddPayment(Payment payment);

        bool DeletePayment(long id);

        List<Payment> GetPaymentsByUser(long id);

        List<Payment> GetPaymentsForMentor(long id);
        void UpdatePayment(Payment payment);
    }
}
