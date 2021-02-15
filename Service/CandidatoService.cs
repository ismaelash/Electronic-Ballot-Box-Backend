using Dapper;
using DataAccess;
using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class CandidateService
    {
        private readonly Context context;
        public static SqlConnection Db = new SqlConnection();

        public CandidateService(Context _context)
        {
            context = _context;

            if (Db.ConnectionString == "")
            {
                Db.ConnectionString = Constants.GET_CONNECTION_STRING();
            }
        }

        //Método POST no serviço
        public async Task<Candidate> CandidatePost(Candidate data)
        {
            data.DataCreation = DateTime.Now;
            data.IsEnable = true;
            context.Candidate.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Método GET no serviço

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await context.Candidate.Where(x => x.IsEnable == true && x.Legend != 0).ToListAsync();
        }

        //Método PUT no serviço
        public async Task<Candidate> PutCandidate(Candidate data)
        {
            context.Entry(data).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<Candidate> CandidateDelete(int? id)
        {
            var data = await context.Candidate.FindAsync(id);
            context.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<Candidate> GetCandidatebyLegend(int legendId)
        {

            var query = $"select * from Candidates where Candidates.Legend = {legendId}";

            var dados = Db.Query<Candidate>(query).FirstOrDefault();

            if (dados == null)
                return new Candidate();
            else
                return dados;
        }
    }
}
