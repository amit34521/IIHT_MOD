using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.SearchService.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        [JsonProperty("id")]
        public long ID { get; set; }
        [Column(TypeName = "varchar(30)")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        [JsonProperty("toc")]
        public string TOC { get; set; }
        [Column(TypeName = "varchar(30)")]
        [JsonProperty("prerequisites")]
        public string Prerequisites { get; set; }
        [JsonProperty("fees")]
        public int Fees { get; set; }
        [JsonProperty("duration")]
        public int duration { get; set; }

        public Training Training { get; set; }
    }
}
