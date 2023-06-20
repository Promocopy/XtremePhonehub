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
    public class XtremeSalesController : ControllerBase
    {
        private readonly XtremeContext _context;
        public XtremeSalesController(XtremeContext context)
        {
            _context=context;
        }

        [HttpGet("GetSalesList")]
        public async Task<ActionResult<IEnumerable<xtremeSales>>> Getlist()
        {
            var user =await _context.Sales.ToListAsync();
            if (user == null)
            {
                return BadRequest("No Sales List");
            }
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var user =await _context.Sales.FindAsync(id);
            if (user == null)
            {
                return NotFound("No id found");
            }
            return Ok(user);
        }

        [HttpPost("AddSales")]
        public async Task<IActionResult> AddSales(xtremeSales sales)
        {
            var user =await _context.Sales.AddAsync(sales);
            if (!ModelState.IsValid)
            {
                return BadRequest("Field not filled");
            }
            _context.SaveChanges();
            return Ok(sales);
        }

        [HttpPut("UpdateSales")]
        public async Task<IActionResult> updateSales(xtremeSales sales)
        {
            var user = _context.Sales.Update(sales);
            if (!ModelState.IsValid)
            {
                return BadRequest("Field not filled");
            }
            _context.SaveChanges();
            return Ok("UPdated");
        }

        [HttpDelete("DeleteSales/{id}")]
        public IActionResult DeleteSales(int id)
        {
            var user = _context.Sales.Where(c => c.Id==id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("User not found");
            }
            _context.Sales.Remove(user);
            _context.SaveChanges();
            return Ok("deleted");
        }
    }
}
