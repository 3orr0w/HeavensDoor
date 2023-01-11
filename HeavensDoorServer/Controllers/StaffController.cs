using HeavensDoorClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private SpaSalonContext _paSalonContext;

        public StaffController(SpaSalonContext paSalonContext)
        {
            _paSalonContext = paSalonContext;
        }


        // GET: api/<StaffController>
        [HttpGet]
        public async Task<ActionResult<List<staff>>> Get()
        {
            return Ok(await _paSalonContext.staff.Include(p => p.IdpostNavigation).Include(p => p.Account).Include(p => p.IdstatusStaffNavigation).ToListAsync());
        }

        // POST api/<StaffController>
        [HttpPost]
        public async Task<ActionResult<staff>> Post(staff client)
        {
            if (_paSalonContext.Accounts.FirstOrDefault(p => p.LoginStaff == client.Account.LoginStaff) != null)
            {
                return BadRequest("Логин уже существует");
            }
            else
            {
                _paSalonContext.staff.Add(client);
                await _paSalonContext.SaveChangesAsync();
                return Ok();
            }
           
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<staff>> Put(int id, [FromBody] staff client)
        {
            if (id != client.Idstaff)
            {
                return BadRequest();
            }
            _paSalonContext.Entry(client).State = EntityState.Modified;
            await _paSalonContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<staff>> Delete(int id)
        {
            var result = await _paSalonContext.staff.FindAsync(id);
            _paSalonContext.staff.Remove(result);
            await _paSalonContext.SaveChangesAsync();
            return Ok();
        }
    }
}
