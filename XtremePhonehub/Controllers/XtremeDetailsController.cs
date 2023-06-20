using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XtremePhonehub.Data;
using XtremePhonehub.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;


namespace XtremePhonehub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XtremeDetailsController : ControllerBase
    {
        private readonly XtremeContext xtreme;
        public XtremeDetailsController(XtremeContext product)
        {
            xtreme = product;
        }
        [HttpGet("Getlist")]
        public async Task<ActionResult<IEnumerable<XtremeDetails>>> GetList()
        {
            var user =await xtreme.Details.ToListAsync();
            if (user.Count==0)
            {
                return NotFound("users not found");
            }
            return Ok(user);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetId(int id)
        {
            var user = await xtreme.Details.FindAsync(id);
            if (user == null)
            {
                return BadRequest("incorrect id");
            }
            return Ok(user);
        }
        [HttpPost("addItem")]
        public IActionResult adduser(XtremeDetails details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("detail not found");
            }
            xtreme.Details.Add(details);
            xtreme.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UPdateuser(XtremeDetails details)
        {
           var user = xtreme.Details.Update(details);
            if (user == null)
            {
                return BadRequest("No user found");
            }
            xtreme.SaveChanges();
            return Ok("Updated");
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            var user = xtreme.Details.Where(c=>c.Id==id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            xtreme.Details.Remove(user);
            xtreme.SaveChanges();
            return Ok("deleted");
        }
    }
}
