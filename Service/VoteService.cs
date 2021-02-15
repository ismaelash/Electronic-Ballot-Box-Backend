using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using Entity.ModelsDapper;
using Microsoft.Data.SqlClient;

namespace Service
{
    public class VoteService
    {
        private readonly Context context;
        public static SqlConnection Db = new SqlConnection();

        public VoteService(Context _context)
        {
            context = _context;

            if (Db.ConnectionString == "")
            {
                Db.ConnectionString = Constants.GET_CONNECTION_STRING();
            }
        }

        //Método POST no serviço
        public async Task<Vote> VotePost(Vote data)
        {

            var query = $"select * from Candidates where Legend = {data.Legend}";
            var dados = Db.Query<Candidate>(query).FirstOrDefault();

            data.DatetimeVote = DateTime.Now;
            data.CandidateId = dados.Id;

            context.Vote.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Método GET no serviço
        public List<ModelGetCandidateVotes> GetCandidateVote()
        {

            var query = @"SELECT ";
            query += @"C.Id as CandidateId, ";
            query += @"C.NameCandidate, ";
            query += @"C.NameViceCandidate, ";
            query += @"C.Legend, ";
            query += @"COUNT(V.Id) as CountVote ";
            query += @"FROM Candidates C ";
            query += @"left join Votes V on C.Id = V.CandidateId ";
            query += @"where C.IsEnable = 1 ";
            query += @"GROUP BY C.Id, C.NameCandidate, C.NameViceCandidate, C.Legend ";
            query += @"order by CountVote desc";

            var dados = Db.Query<ModelGetCandidateVotes>(query).ToList();

            if (dados != null)
                return dados;
            else
                return new List<ModelGetCandidateVotes>();
        }
    }
}
