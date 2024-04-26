using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : ControllerBase
    {
        private readonly IProfilingRepositories _rep;

        public ProfilingController(IProfilingRepositories rep)
        {
            _rep = rep;
        }

        // GET: api/<ProfilingController>
        [HttpGet]
        public ActionResult<IEnumerable<Profiling>> Get()
        {
            var result = _rep.GetAll();
            return Ok(result);
        }

        //// GET api/<ProfilingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ProfilingController>
        [HttpPost]
        public ActionResult<Profiling> Post([FromBody] Profiling newProfilin)
        {
            if(newProfilin == null)
            {
                return BadRequest("");
            }
            var item = _rep.Add(newProfilin);
            return Ok(item);
        }

        // PUT api/<ProfilingController>/5
        [HttpPut("{id}")]
        public ActionResult<Profiling> Put(int id, [FromBody] Profiling update)
        {
            try
            {
                Profiling foundItem = _rep.Update(update,id);
                if(foundItem == null)
                {
                    return BadRequest("");
                }
                return Ok(foundItem);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<ProfilingController>/5
        [HttpDelete("{id}")]
        public ActionResult<Profiling> Delete(int id)
        {
            Profiling profiling = _rep.Delete(id);
            if (profiling == null)
            {
                return NotFound();
            }
            return Ok(profiling);
        }
    }
}
