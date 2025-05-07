using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public ActionResult<List<Shift>> GetAllShifts()
        {
            return Ok(_shiftService.GetAllShifts());
        }

        [HttpGet("{id}")]
        public ActionResult<Shift> GetShiftById(int id)
        {
            var result = _shiftService.GetShiftById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Shift> CreateShift(Shift shift)
        {
            return Ok(_shiftService.CreateShift(shift));
        }

        [HttpPut("{id}")]
        public ActionResult<Shift> UpdateShift(int id, [FromBody] Shift updatedShift)
        {
            var result = _shiftService.UpdateShift(id, updatedShift);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteShift (int id)
        {
            var result = _shiftService.GetShiftById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
