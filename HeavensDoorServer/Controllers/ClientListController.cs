using HeavensDoorClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientListController : ControllerBase
    {
        private SpaSalonContext _paSalonContext;

        public ClientListController(SpaSalonContext paSalonContext)
        {
            _paSalonContext = paSalonContext;
        }

        // GET: api/<ClientListController>
        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _paSalonContext.Clients.ToListAsync());
        }

        // GET api/<ClientListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var clients = await _paSalonContext.Clients.FirstOrDefaultAsync(p => p.Idclient == id);
            if (clients == null)
            {
                return NotFound();
            }
            return new ObjectResult(clients);
        }

        // POST api/<ClientListController>
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            _paSalonContext.Clients.Add(client);
            await _paSalonContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<ClientListController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(int id, [FromBody] Client client)
        {
            if (id != client.Idclient)
            {
                return BadRequest();
            }
            _paSalonContext.Entry(client).State = EntityState.Modified;
            await _paSalonContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ClientListController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var result = await _paSalonContext.Clients.FindAsync(id);
            _paSalonContext.Clients.Remove(result);
            await _paSalonContext.SaveChangesAsync();
            return Ok();
        }
    }
}
