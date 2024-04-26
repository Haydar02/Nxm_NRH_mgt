using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrouppController : ControllerBase
    {
        private readonly IGroupRepositories _rep;

        public GrouppController(IGroupRepositories rep)
        {
            _rep = rep;
        }

        // GET: api/<GrouppController>
        [HttpGet]
        public ActionResult<IEnumerable<Groupp>> Get()
        {
            var groupp = _rep.GetGroups();
            return Ok(groupp);
        }

        // GET api/<GrouppController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GrouppController>
        [HttpPost]
        public ActionResult<Groupp> Post([FromBody] Groupp newGroupp)
        {
            if(newGroupp == null)
            {
                return BadRequest("Group not found");
               
            }
            var createdGroupp = _rep.Add(newGroupp);
            return Ok(createdGroupp);
        }

        // PUT api/<GrouppController>/5
        [HttpPut("{id}")]
        public ActionResult<Groupp> Put(int id, [FromBody] Groupp update)
        {
            try
            {
                Groupp foundGroupp = _rep.update(update, id);
                if(foundGroupp == null)
                {
                    return BadRequest("");
                }
                return Ok(foundGroupp);
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<GrouppController>/5
        [HttpDelete("{id}")]
        public ActionResult<Groupp> Delete(int id)
        {
            var item = _rep.delete(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
