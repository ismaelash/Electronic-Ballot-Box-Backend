using Entity;
using Entity.ModelsDapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicBallotBox.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VoteController : Controller
    {
        private readonly VoteService serviceVote;

        public VoteController(VoteService _service)
        {
            serviceVote = _service;
        }

        //Método POST no controller
        [HttpPost]
        public async Task<ActionResult<Vote>> VotePost([FromBody] Vote dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data = await serviceVote.VotePost(dados);
                return data;
            }
        }

        [HttpGet]
        public List<ModelGetCandidateVotes> GetCandidateVote()
        {
            var data = serviceVote.GetCandidateVote();
            return data;
        }
    }
}
