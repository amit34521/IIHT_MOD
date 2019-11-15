using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.SearchService.Models
{
    [Table("Mentors")]
    public class Mentor
    {
        [Key]
        [JsonProperty("id")]
        public long Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("userName")]
        [Required]
        public string userName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("password")]
        [Required]
        public string password { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("lastName")]
        public string lastName { get; set; }
        [JsonProperty("contactNumber")]
        public long contactNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("registrationCode")]
        public string registrationCode { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("linkedinUrl")]
        public string linkedinUrl { get; set; }
        [JsonProperty("yearsOfExperience")]
        public int yearsOfExperience { get; set; }
        [JsonProperty("active")]
        public bool active { get; set; }
        [JsonProperty("confirmedSignup")]
        public bool confirmedSignup { get; set; }
        [JsonProperty("resetPasswordDate")]
        public DateTime resetPasswordDate { get; set; }
        [JsonProperty("resetPassword")]
        public bool resetPassword { get; set; }

        public Training Training { get; set; }
        public Mentor()
        {
            this.active = false;
            this.resetPassword = false;
            this.confirmedSignup = false;
        }
    }
}
