using Microsoft.AspNetCore.Mvc;
using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nxm_NRH_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileRoleController : ControllerBase
    {
        private readonly IProfilingRoleRepositories _rep;

        public ProfileRoleController(IProfilingRoleRepositories rep)
        {
            _rep = rep;
        }

        // GET: api/<ProfileRoleController>
        [HttpGet]
        public ActionResult<IEnumerable<ProfileRole>> Get()
        {
           var result = _rep.GetAll();
            return Ok(result);
        }

        // GET api/<ProfileRoleController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ProfileRoleController>
        [HttpPost]
        public ActionResult<ProfileRole> Post([FromBody] ProfileRole newProfileRole)
        {
            if(newProfileRole == null)
            {
                return BadRequest();
            }
            var result = _rep.Add(newProfileRole);
            return Ok(result);
        }

        // PUT api/<ProfileRoleController>/5
        [HttpPut("{id}")]
        public ActionResult<ProfileRole> Put(int id, [FromBody] ProfileRole update)
        {
            try
            {
                ProfileRole foundItem = _rep.Update(update, id);
                if(foundItem == null)
                {
                    return BadRequest();
                }
                return Ok(foundItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfileRoleController>/5
        [HttpDelete("{id}")]
        public ActionResult<ProfileRole> Delete(int id)
        {
            ProfileRole foundItem = _rep.Delete(id);
            if( foundItem == null)
            {
                return BadRequest();
            }
            return Ok(foundItem);
        }
    }
}
