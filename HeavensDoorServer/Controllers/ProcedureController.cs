using HeavensDoorClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using HeavensDoorServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private IHubContext<Service> hubContex;
        private SpaSalonContext _paSalonContext;

        public ProcedureController(SpaSalonContext spaSalonContext, IHubContext<Service> hub)
        {
            this._paSalonContext = spaSalonContext;
            this.hubContex = hub;
        }
        // GET: api/<ProcedureController>
        [HttpGet]
        public async Task<ActionResult<List<Procedure>>> Get()
        {
            return Ok(await _paSalonContext.Procedures.Include(p => p.MaterialForProcedures).ThenInclude(p => p.IdmaterialNavigation).ThenInclude(p=>p.MaterialToStorage).ToListAsync());
        }

        [HttpGet("GetPost/{postId}")]
        public async Task<ActionResult<List<Procedure>>> GetPost(int postId)
        {
            return Ok(await _paSalonContext.Procedures.Where(p=>p.ProcedureToPosts.FirstOrDefault().Idpost==postId).Include(p => p.MaterialForProcedures).ThenInclude(p => p.IdmaterialNavigation).ToListAsync());
        }

        // GET api/<ProcedureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProcedureController>
        [HttpPost]
        public async Task<ActionResult<Procedure>> Post(Procedure client)
        {
            _paSalonContext.Procedures.Add(client);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateProc");

            return Ok();
        }

        // PUT api/<ProcedureController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Procedure>> Put(int id, [FromBody] Procedure client)
        {
            if (id != client.Idprocedure)
            {
                return BadRequest();
            }
            foreach (var item in client.MaterialForProcedures)
            {
                item.Idprocedure = id;
                //item.Idmaterial = item..Idmaterial;
            }

            var procedureInBD = _paSalonContext.Procedures.Include(p => p.MaterialForProcedures).FirstOrDefault(p => p.Idprocedure == id);
            //procedureInBD.MaterialForProcedures.ToList().AddRange(client.MaterialForProcedures);
            procedureInBD.MaterialForProcedures.Clear();
            foreach (var item in client.MaterialForProcedures)
            {
                procedureInBD.MaterialForProcedures.Add(item);
            }
            _paSalonContext.Entry(procedureInBD).CurrentValues.SetValues(client);
            //_paSalonContext.Entry(client).State = EntityState.Modified;          
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateProc");

            return Ok();
        }

        // DELETE api/<ProcedureController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Procedure>> Delete(int id)
        {
            var result = await _paSalonContext.Procedures.FindAsync(id);
            _paSalonContext.Procedures.Remove(result);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateProc");

            return Ok();
        }
    }
}
