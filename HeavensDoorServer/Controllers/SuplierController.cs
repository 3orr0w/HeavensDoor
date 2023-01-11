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
    public class SuplierController : ControllerBase
    {
        private SpaSalonContext _paSalonContext;

        public SuplierController(SpaSalonContext paSalonContext)
        {
            _paSalonContext = paSalonContext;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<List<Suplier>>> Get()
        {
            return Ok(await _paSalonContext.Supliers.ToListAsync());
        }
    }
}
