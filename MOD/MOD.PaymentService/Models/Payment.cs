using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.PaymentService.Models
{
    public class Payment
    {
        [Key]
        [JsonProperty("Id")]
        public long Id { get; set; }
        [ForeignKey("Mentor")]
        [JsonProperty("mentorId")]
        public long mentorId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("mentorName")]
        public string mentorName { get; set; }
        [ForeignKey("Training")]
        [JsonProperty("trainingId")]
        public long trainingId { get; set; }
        [Column(TypeName ="varchar(20)")]
        [JsonProperty("txnType")]
        public string txnType { get; set; }

        [JsonProperty("amount")]
        public int amount { get; set; }

        [JsonProperty("datetime")]
        public DateTime datetime { get; set; }

        [JsonProperty("remarks")]
        public string remarks { get; set; }

        public Mentor Mentor { get; set; }
        public Training Training { get; set; }
    }
}
