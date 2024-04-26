using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        private readonly IParticipantRepositories _rep;

        public ParticipantController(IParticipantRepositories rep)
        {
            _rep = rep;
        }

        // GET: api/<ParticipantController>
        [HttpGet]
        public ActionResult<IEnumerable<Participant>> Get()
        {
           var result = _rep.GetAll();
            return Ok(result);
        }

        // GET api/<ParticipantController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ParticipantController>
        [HttpPost]
        public ActionResult<Participant> Post([FromBody] Participant newParticipant)
        {
            if(newParticipant == null)
            {
                return BadRequest("");
            }
            var created = _rep.Add(newParticipant);
            return Ok(created);
        }

        // PUT api/<ParticipantController>/5
        [HttpPut("{id}")]
        public ActionResult<Participant> Put(int id, [FromBody] Participant update)
        {
            try
            {
                Participant participant = _rep.Update(update, id);
                if(participant == null)
                {
                    return BadRequest("");
                }
                return Ok(participant);
            }catch(Exception ex)
            {
                throw ex; 
            }
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete("{id}")]
        public ActionResult<Participant> Delete(int id)
        {
            var Item = _rep.Delete(id);
           if(Item == null)
            {
                return NotFound();
            }
           return Ok(Item);
        }
    }
}
