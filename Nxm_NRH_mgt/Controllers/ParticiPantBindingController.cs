using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticiPantBindingController : ControllerBase
    {
        private readonly IParticiPantBindingRepositories _repository;

        public ParticiPantBindingController(IParticiPantBindingRepositories repository)
        {
            _repository = repository;
        }

        // GET: api/<ParticiPantBindingController>
        [HttpGet]
        public ActionResult<IEnumerable<ParticiPantBinding>> GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        // GET api/<ParticiPantBindingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ParticiPantBindingController>
        [HttpPost]
        public ActionResult<ParticiPantBinding> Post([FromBody] ParticiPantBinding newParticiPant)
        {
            if(newParticiPant == null)
            {
                return BadRequest();
            }
            var result = _repository.Add(newParticiPant);
            return Ok(result);
        }

        // PUT api/<ParticiPantBindingController>/5
        [HttpPut("{id}")]
        public ActionResult<ParticiPantBinding> Put(int id, [FromBody] ParticiPantBinding update)
        {
            try
            {
                ParticiPantBinding foundItem = _repository.Update(update, id);
                if(foundItem == null)
                {
                    return BadRequest();
                }
                return Ok(foundItem);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ParticiPantBindingController>/5
        [HttpDelete("{id}")]
        public ActionResult<ParticiPantBinding> Delete(int id)
        {
            ParticiPantBinding foundItem = _repository.Delete(id);
            if( foundItem == null)
            {
                return NotFound();
            }
            return Ok(foundItem);
        }
    }
}
