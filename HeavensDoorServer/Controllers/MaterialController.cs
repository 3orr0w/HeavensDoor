using HeavensDoorClass;
using HeavensDoorServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IHubContext<Service> hubContex;
        private SpaSalonContext _paSalonContext;

        public MaterialController(SpaSalonContext spaSalonContext, IHubContext<Service> hub)
        {
            this._paSalonContext = spaSalonContext;
            this.hubContex = hub;
        }

        // GET: api/<MaterialController>
        [HttpGet]
        public async Task<ActionResult<List<Material>>> Get()
        {
            return Ok(await _paSalonContext.Materials.Include(p=>p.MaterialToStorage).Include(p=>p.MaterialForProcedures).ToListAsync());
        }

        // GET api/<MaterialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MaterialController>
        [HttpPost]
        public async Task<ActionResult<Material>> Post(Material client)
        {
            _paSalonContext.Materials.Add(client);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Material>> Put(int id, [FromBody] Material client)
        {
            if (id != client.Idmaterial)
            {
                return BadRequest();
            }
            _paSalonContext.Entry(client).State = EntityState.Modified;
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> Delete(int id)
        {
            var result = await _paSalonContext.Materials.FindAsync(id);
            _paSalonContext.Materials.Remove(result);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }
    }
}
