using Entity;
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
    public class CandidateController : Controller
    {
        private readonly CandidateService serviceCandidate;

        public CandidateController(CandidateService _service)
        {
            serviceCandidate = _service;
        }

        #region Get

        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetCandidate()
        {
            var dados = await serviceCandidate.GetCandidates();
            return dados;
        }

        [Route("Legend/{id}")]
        [HttpGet]
        public async Task<ActionResult<Candidate>> GetCandidatebyLegend(int id)
        {
            var dados = await serviceCandidate.GetCandidatebyLegend(id);

            if (dados.Legend != 0)
            {
                return Ok(dados);
            }
            else
            {
                return NotFound("Candidate not found");
            }
        }

        #endregion

        #region Post

        //Método POST no controller
        [HttpPost]
        public async Task<ActionResult<Candidate>> CandidatePost([FromBody] Candidate dados)
        {

            if (dados.Legend == 0)
            {
                return BadRequest("The legend 0 is for candidate null");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var dataCandidate = await serviceCandidate.GetCandidatebyLegend(dados.Legend);

                    if (dataCandidate.Id != 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var data = await serviceCandidate.CandidatePost(dados);
                        return data;
                    }
                }
            }
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<Candidate>> CandidateDelete(int? id)
        {
            if (id == null)
                return BadRequest();
            else
            {
                var data = await serviceCandidate.CandidateDelete(id);
                return data;
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<Candidate>> PutCandidate(int? id, [FromBody] Candidate candidate)
        {
            if (id == candidate.Id)
            {
                var data = await serviceCandidate.PutCandidate(candidate);
                return data;
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
