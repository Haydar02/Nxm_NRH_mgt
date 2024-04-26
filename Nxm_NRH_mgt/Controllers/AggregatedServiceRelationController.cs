using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregatedServiceRelationController : ControllerBase
    {
        private readonly IAggregatedServiceRelationRepositories _rep;

        public AggregatedServiceRelationController(IAggregatedServiceRelationRepositories rep)
        {
            _rep = rep;
        }

        // GET: api/<AggregatedServiceRelationController>
        [HttpGet]
        public ActionResult<IEnumerable<AggregatedServiceRelation>> GetAll()
        {
            var result = _rep.GetAll();
            return Ok(result);
        }

        // GET api/<AggregatedServiceRelationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AggregatedServiceRelationController>
        [HttpPost]
        public ActionResult<AggregatedServiceRelation> Post([FromBody] AggregatedServiceRelation newItem)
        {
            if(newItem == null)
            {
                return BadRequest();
            }
            var result = _rep.Add(newItem);
            return Ok(result);
        }

        // PUT api/<AggregatedServiceRelationController>/5
        [HttpPut("{id}")]
        public ActionResult<AggregatedServiceRelation> Put(int id, [FromBody] AggregatedServiceRelation update)
        {
            try
            {
                AggregatedServiceRelation foundItem = _rep.Update(update, id);
                if(foundItem == null)
                {
                    return BadRequest();
                }
                return Ok(foundItem);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<AggregatedServiceRelationController>/5
        [HttpDelete("{id}")]
        public ActionResult<AggregatedServiceRelation> Delete(int id)
        {
            AggregatedServiceRelation foundItem = _rep.Delete(id);
            if(foundItem == null)
            {
                return NotFound();
            }
            return Ok(foundItem);
        }
    }
}
