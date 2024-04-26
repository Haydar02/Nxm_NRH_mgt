using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregatedServiceController : ControllerBase
    {
        private readonly IAggregatedRepositpries _rep;

        public AggregatedServiceController(IAggregatedRepositpries rep)
        {
            _rep = rep;
        }

        // GET: api/<AggregatedServiceController>
        [HttpGet]
        public ActionResult<IEnumerable<AggregatedService>> Get()
        {
            var result = _rep.GetAll();
            return Ok(result);
        }

        // GET api/<AggregatedServiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AggregatedServiceController>
        [HttpPost]
        public ActionResult<AggregatedService> Post([FromBody] AggregatedService service)
        {
            if (service == null)
            {
                return BadRequest("");
            }
            var result = _rep.Add(service);
            return Ok(result);
        }

        // PUT api/<AggregatedServiceController>/5
        [HttpPut("{id}")]
        public ActionResult<AggregatedService> Put(int id, [FromBody] AggregatedService update)
        {
            try
            {
                AggregatedService foundItem = _rep.Update(update, id);
                if (foundItem == null)
                {
                    return BadRequest("");
                }
                return Ok(foundItem);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<AggregatedServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult<AggregatedService> Delete(int id)
        {
            AggregatedService result = _rep.Delete(id);
            if(result == null)
            {
                return NotFound("The item dosent found");
            }
            return Ok(result);
        }
    }
}
