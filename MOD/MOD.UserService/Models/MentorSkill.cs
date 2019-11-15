using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.UserService.Models
{
    [Table("MentorSkills")]
    public class MentorSkill
    {
        [Key]
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("mentorId")]
        public long mentorId { get; set; }
        [JsonProperty("skillId")]
        public long skillId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("mentorName")]
        public string mentorName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("skillName")]
        public string skillName { get; set; }
        [JsonProperty("selfRating")]
        public int selfrating { get; set; }
        [JsonProperty("yearsOfExperience")]
        public int yearsOfExperience { get; set; }
        [JsonProperty("trainingsDelivered")]
        public int trainingsDelivered { get; set; }
        [JsonProperty("facilitiesOffered")]
        public int facilitiesOffered { get; set; }
    }
}
