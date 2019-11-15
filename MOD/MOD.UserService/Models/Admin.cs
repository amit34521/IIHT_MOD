using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.UserService.Models
{
    [Table("Admin")]
    public class Admin
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
    }
}
