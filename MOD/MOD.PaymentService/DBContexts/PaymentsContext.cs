using Microsoft.EntityFrameworkCore;
using MOD.PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.PaymentService.DBContexts
{
    public class PaymentsContext :DbContext
    {
        public PaymentsContext(DbContextOptions<PaymentsContext> options) 
            : base(options)
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
