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
    public class DeliveryController : ControllerBase
    {
        private IHubContext<Service> hubContex;
        private SpaSalonContext _paSalonContext;

        public DeliveryController(SpaSalonContext spaSalonContext, IHubContext<Service> hub)
        {
            this._paSalonContext = spaSalonContext;
            this.hubContex = hub;
        }

        // GET: api/<ClientListController>
        [HttpGet]
        public async Task<ActionResult<List<Delivery>>> Get()
        {
            return Ok(await _paSalonContext.Deliveries.Include(p=>p.IdsupplierNavigation)
                .Include(p=>p.IdStatusDeliveryNavigation).Include(p=>p.IdstaffNavigation).Include(p=>p.MaterialInDeliveries).ToListAsync());
        }

        // GET api/<ClientListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> Get(int id)
        {
            var clients = await _paSalonContext.Deliveries.FirstOrDefaultAsync(p => p.Iddelivey == id);
            if (clients == null)
            {
                return NotFound();
            }
            return new ObjectResult(clients);
        }

        //[HttpPost("MaterialInDelivery")]
        //public async Task<ActionResult<Delivery>> PostMaterial(Delivery ses)
        //{
        //    //var warehouse = _paSalonContext.Materials.Include(p => p.MaterialToStorage).FirstOrDefault();
        //    //var id = _paSalonContext.Deliveries.Find(ses.Iddelivey);
        //    //id.IdStatusDelivery = 1;
        //    //id.DateDelivery = System.DateTime.Now;
        //    //foreach (var material in ses.MaterialInDeliveries)
        //    //{
        //    //        var productinwarehouse = warehouse.MaterialToStorage.find(p => p.Idmaterial == ses.Iddelivey);
        //    //        productinwarehouse.AmountMaterialInDelivery += material.AmountMaterialInDelivery;
        //    //        _paSalonContext.MaterialToStorages.Find(material.Idmaterial).AmountMaterialToStorage += material.AmountMaterialInDelivery;
               
        //    //        _paSalonContext.MaterialToStorages.Add(new MaterialToStorage
        //    //        {
        //    //            Idmaterial = material.Idmaterial,
        //    //            AmountMaterialToStorage = material.AmountMaterialInDelivery
        //    //        });
                


        //    //}

        //    //await _paSalonContext.SaveChangesAsync();
        //    //return Ok();
        //}

        // POST api/<ClientListController>
        [HttpPost]
        public async Task<ActionResult<Delivery>> Post(Delivery client)
        {
            _paSalonContext.Deliveries.Add(client);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateDel");
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }

        // PUT api/<ClientListController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Delivery>> Put(int id, [FromBody] Delivery client)
        {
            if (id != client.Iddelivey)
            {
                return BadRequest();
            }

            client.IdStatusDelivery = 1;
            client.DateDelivery = System.DateTime.Now;
            foreach (var material in client.MaterialInDeliveries)
            {

                if (_paSalonContext.MaterialToStorages.Find(material.Idmaterial) != null)
                {
                    _paSalonContext.MaterialToStorages.Find(material.Idmaterial).AmountMaterialToStorage += material.AmountMaterialInDelivery;
                }
                else
                {
                    _paSalonContext.MaterialToStorages.Add(new MaterialToStorage
                    {
                        Idmaterial = material.Idmaterial,
                        AmountMaterialToStorage = material.AmountMaterialInDelivery
                    });
                }
            }
            _paSalonContext.Entry(client).State = EntityState.Modified;
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateDel");
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }

        // DELETE api/<ClientListController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Delivery>> Delete(int id)
        {
            var result = await _paSalonContext.Deliveries.FindAsync(id);
            _paSalonContext.Deliveries.Remove(result);
            await _paSalonContext.SaveChangesAsync();
            await hubContex.Clients.All.SendAsync("UpdateDel");
            await hubContex.Clients.All.SendAsync("UpdateMaterials");

            return Ok();
        }
    }
}
