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
    public class StatusDeliveryController : ControllerBase
    {

        private SpaSalonContext _paSalonContext;

        public StatusDeliveryController(SpaSalonContext paSalonContext)
        {
            _paSalonContext = paSalonContext;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<List<StatusDelivery>>> Get()
        {
            return Ok(await _paSalonContext.StatusDeliveries.ToListAsync());
        }
    }
}
