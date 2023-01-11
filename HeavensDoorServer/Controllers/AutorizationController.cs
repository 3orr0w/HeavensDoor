using HeavensDoorServer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeavensDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizationController : ControllerBase
    {
        private SpaSalonContext _paSalonContext;

        public AutorizationController(SpaSalonContext paSalonContext)
        {
            _paSalonContext = paSalonContext;
        }



        // POST api/<AutorizationController>
        [HttpPost]
        public IActionResult Post([FromBody] Autorization au)
        {
            var result = _paSalonContext.staff.Include(p => p.IdpostNavigation).FirstOrDefault(p => p.Account.LoginStaff == au.Login && p.Account.PasswordStaff == au.Password);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
