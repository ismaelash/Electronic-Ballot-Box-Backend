using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Candidates")]
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameCandidate { get; set; }
        [Required]
        public string NameViceCandidate { get; set; }
        public DateTime DataCreation { get; set; }
        [Required]
        public int Legend { get; set; }
        public string Image { get; set; }
        public bool IsEnable { get; set; }
    }
}
