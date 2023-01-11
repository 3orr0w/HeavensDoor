using HeavensDoorClass;
using HeavensDoorServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private IHubContext<Service> hubContex;
        private SpaSalonContext spaSalonContext;

        public SessionController(SpaSalonContext spaSalonContext, IHubContext<Service> hub)
        {
            this.spaSalonContext = spaSalonContext;
            this.hubContex = hub;
        }

        // GET: api/<SessionController>
        [HttpGet]
        public async Task<ActionResult<List<Session>>> Get()
        {
            return Ok(await spaSalonContext.Sessions.Include(p => p.IdclientNavigation).Include(p => p.IdstaffNavigation)
                .Include(p => p.IdproceduresNavigation).ThenInclude(p => p.MaterialForProcedures).ThenInclude(p => p.IdmaterialNavigation).ThenInclude(p => p.MaterialToStorage)
                .Include(p => p.IdstatusNavigation).ToListAsync());
        }

        // GET api/<SessionController>/5
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

        // POST api/<ClientListController>
        [HttpPost]
        public async Task<ActionResult<Session>> Post(Session client)
        {
            var staff = spaSalonContext.staff.AsNoTracking().FirstOrDefault(p => p.Idstaff == client.Idstaff);
            var procedure = spaSalonContext.Procedures.AsNoTracking().Include(p => p.ProcedureToPosts).AsNoTracking().FirstOrDefault(p => p.Idprocedure == client.Idprocedures);

            if (staff.Idpost == procedure.ProcedureToPosts.FirstOrDefault().Idpost)
            {

                spaSalonContext.Sessions.Add(client);
                await spaSalonContext.SaveChangesAsync();
                await hubContex.Clients.All.SendAsync("UpdateAdd");
                return Ok();
            }
            else return BadRequest("Выбранный сотрудник не может проводить выбранную процедуру. Выберите другого сотрудника или процедуру");
        }

        [HttpPost("MaterialInSession")]
        public async Task<ActionResult<Session>> PostMaterial(Session ses)
        {
            ses.DateTime = System.DateTime.Now;
            ses.Idstatus = 2;
            foreach (var material in ses.IdproceduresNavigation.MaterialForProcedures)
            {
                var materialInBd = spaSalonContext.MaterialToStorages.Find(material.Idmaterial);
                if (materialInBd.AmountMaterialToStorage < material.AmountMaterialToProcedures)
                {
                    return BadRequest("Недостаточно материалов");
                }
                else
                {
                    materialInBd.AmountMaterialToStorage -= material.AmountMaterialToProcedures;

                }
            }
            spaSalonContext.Entry(ses).State = EntityState.Modified;
            await spaSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateAdd");

            return Ok();
        }

        // PUT api/<ClientListController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Session>> Put(int id, [FromBody] Session client)
        {
            var staff = spaSalonContext.staff.AsNoTracking().FirstOrDefault(p => p.Idstaff == client.Idstaff);
            var procedure = spaSalonContext.Procedures.AsNoTracking().Include(p => p.ProcedureToPosts).AsNoTracking().FirstOrDefault(p => p.Idprocedure == client.Idprocedures);

            if (staff.Idpost == procedure.ProcedureToPosts.FirstOrDefault().Idpost)
            {
                if (id != client.Idsession)
                {
                    return BadRequest();
                }
                spaSalonContext.Entry(client).State = EntityState.Modified;
                await spaSalonContext.SaveChangesAsync();
                await hubContex.Clients.All.SendAsync("UpdateAdd");

                return Ok();
            }
            else return BadRequest("Выбранный сотрудник не может проводить выбранную процедуру. Выберите другого сотрудника или процедуру");
        }

        // DELETE api/<ClientListController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Session>> Delete(int id)
        {
            var result = await spaSalonContext.Sessions.FindAsync(id);
            spaSalonContext.Sessions.Remove(result);
            await spaSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateAdd");

            return Ok();
        }
    }
}
