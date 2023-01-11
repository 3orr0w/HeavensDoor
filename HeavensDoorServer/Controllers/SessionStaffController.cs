using HeavensDoorClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionStaffController : ControllerBase
    {
        private SpaSalonContext spaSalonContext;

        public SessionStaffController(SpaSalonContext spaSalonContext)
        {
            this.spaSalonContext = spaSalonContext;
        }

        // GET: api/<SessionStaffController>
        [HttpGet]
        public async Task<ActionResult<List<Session>>> Get()
        {
            return Ok(await spaSalonContext.Sessions.Include(p => p.IdclientNavigation).Include(p => p.IdstaffNavigation)
                .Include(p => p.IdproceduresNavigation).ThenInclude(p => p.MaterialForProcedures).ThenInclude(p => p.IdmaterialNavigation)
                .Include(p => p.IdstatusNavigation).ToListAsync());
        }

        // GET api/<SessionStaffController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> Get(int id)
        {

            var clients = await spaSalonContext.Sessions.FirstOrDefaultAsync(p => p.Idsession == id);
            if (clients == null)
            {
                return NotFound();
            }
            return new ObjectResult(clients);
        }

        // POST api/<SessionStaffController>
        [HttpPost]
        public async Task<ActionResult<Session>> Post(Session client)
        {
            spaSalonContext.Sessions.Add(client);
            await spaSalonContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<SessionStaffController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Session>> Put(int id, [FromBody] Session client)
        {
            if (id != client.Idsession)
            {
                return BadRequest();
            }
            spaSalonContext.Entry(client).State = EntityState.Modified;
            await spaSalonContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SessionStaffController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Session>> Delete(int id)
        {
            var result = await spaSalonContext.Sessions.FindAsync(id);
            spaSalonContext.Sessions.Remove(result);
            await spaSalonContext.SaveChangesAsync();
            return Ok();
        }
    }
}
