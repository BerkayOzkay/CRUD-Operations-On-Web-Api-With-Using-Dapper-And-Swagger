using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperWeb.Model;
using DapperWeb.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOffice _OfficeRepo;

        public OfficeController(IOffice OfficeRepo)
        {
            _OfficeRepo = OfficeRepo;
        }
       

        [HttpGet]
        public async Task<IEnumerable<Staff>> GetStaffs()
        {
            return await _OfficeRepo.Get();
        }

        [HttpGet("{SiparisKod}")]
        public async Task<ActionResult<Staff>> GetStaffs(Guid SiparisKod)
        {
            return await _OfficeRepo.Get(SiparisKod);
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaffs([FromBody] Staff staff)
        {
            var newStaff = await _OfficeRepo.Create(staff);
            return CreatedAtAction(nameof(GetStaffs), new { SiparisKod = newStaff.SiparisKod }, newStaff);
        }

        [HttpPut]
        public async Task<ActionResult> PutStaffs(Guid SiparisKod, [FromBody] Staff staff)
        {
            if (SiparisKod != staff.SiparisKod)
            {
                return BadRequest();
            }

            await _OfficeRepo.Update(staff);

            return NoContent();
        }

        [HttpDelete("{SiparisKod}")]
        public async Task<ActionResult> Delete(Guid SiparisKod)
        {
            var staffToDelete = await _OfficeRepo.Get(SiparisKod);
            if (staffToDelete == null)
                return NotFound();

            await _OfficeRepo.Delete(staffToDelete.SiparisKod);
            return NoContent();
        }
    }
}
