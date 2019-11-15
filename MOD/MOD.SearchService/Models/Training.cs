using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.SearchService.Models
{
    public class Training
    {
        [Key]
        [JsonProperty("Id")]
        public long Id { get; set; }
        [ForeignKey("User")]
        [JsonProperty("userId")]
        public long userId { get; set; }
        [ForeignKey("Mentor")]
        [JsonProperty("mentorsId")]
        public long mentorsId { get; set; }
        [ForeignKey("Skill")]
        [JsonProperty("skillId")]
        public long skillId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("userName")]
        public string userName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("mentorName")]
        public string mentorName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [JsonProperty("skillName")]
        public string skillName { get; set; }
        [Column(TypeName ="varchar(1)")]
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("progress")]
        public int progress { get; set; }
        [JsonProperty("rating")]
        public float rating { get; set; }
        [JsonProperty("startDate")]
        public DateTime startDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime endDate { get; set; }
        [JsonProperty("startTime")]
        public string startTime { get; set; }
        [JsonProperty("endTime")]
        public string endTime { get; set; }
        [JsonProperty("amountReceived")]
        public int amountReceived { get; set; }
        public Skill Skill { get; set; }
        public Training()
        {
            this.rating = 0.0f;
        }
    }
}
