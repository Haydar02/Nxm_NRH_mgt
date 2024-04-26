using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.NxmServices;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly IServiceRepositores _rep;

        public ServiceController(IServiceRepositores rep)
        {
            _rep = rep;
        }




        // GET: api/<ServiceController>
        [HttpGet]
        public ActionResult<IEnumerable<ServicE>> GetAll()
        {
           var services = _rep.GetAll();
            return Ok(services);
        }

        // GET api/<ServiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ServiceController>
        [HttpPost]
        public ActionResult<ServicE> Post([FromBody] ServicE newService)
        {
           if(newService == null)
            {
                return BadRequest("Services Data is null");
            }
           var CreatedService = _rep.AddService(newService);
            return CreatedService;

        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public ActionResult<ServicE> Put(int id, [FromBody] ServicE updatedService)
        {
            try
            {
                ServicE updateService = _rep.Update(updatedService,id);
                if (updateService == null)
                {
                    return NotFound();
                }
                return Ok(updateService);
            }
           catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
           
          

        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult<ServicE> Delete(int id)
        {
            var service = _rep.Delete(id);
            if(service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
    }
}
