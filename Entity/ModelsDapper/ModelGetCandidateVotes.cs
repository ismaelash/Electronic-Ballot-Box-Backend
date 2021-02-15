namespace Entity.ModelsDapper
{
    public class ModelGetCandidateVotes
    {
        public int CandidateId { get; set; }
        public string NameCandidate { get; set; }
        public string NameViceCandidate { get; set; }
        public int Legend { get; set; }
        public int CountVote { get; set; }
    }
}