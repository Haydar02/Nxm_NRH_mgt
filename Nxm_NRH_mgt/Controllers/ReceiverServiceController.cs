using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverServiceController : ControllerBase
    {
        private readonly IReceiverServiceRepositories _repository;

        public ReceiverServiceController(IReceiverServiceRepositories repository)
        {
            _repository = repository;
        }

        // GET: api/<ReceiverServiceController>
        [HttpGet]
        public ActionResult<IEnumerable<ReceiverService>> Get()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        // GET api/<ReceiverServiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ReceiverServiceController>
        [HttpPost]
        public ActionResult<ReceiverService> Post([FromBody] ReceiverService newReceiver)
        {
            if(newReceiver == null)
            {
                return BadRequest("");
            }
            var result = _repository.Add(newReceiver);
            return Ok(result);
        }

        // PUT api/<ReceiverServiceController>/5
        [HttpPut("{id}")]
        public ActionResult<ReceiverService> Put(int id, [FromBody] ReceiverService update)
        {
            try
            {
                ReceiverService receiver = _repository.Update(update, id);
                if (receiver == null)
                {
                    return BadRequest();
                }
                return Ok(receiver);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<ReceiverServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult<ReceiverService> Delete(int id)
        {
            ReceiverService foundItem= _repository.Delete(id);
            if(foundItem == null)
            {
                return NotFound();
            }
            return Ok(foundItem);
        }
    }
}
