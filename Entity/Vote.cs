using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Vote")]
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime DatetimeVote { get; set; }
        public int Legend { get; set; }
    }
}
