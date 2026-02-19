using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Models;
using ShiftsLogger.API.Models.DTOs.Shift;
using ShiftsLogger.API.Services;

namespace ShiftsLogger.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftController : ControllerBase
{
    private readonly IShiftService _shiftService;

    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetShiftDto>> GetShiftById(int id)
    {
        var shift = await _shiftService.GetShiftByIdAsync(id);

        if (shift is null)
        {
            return NotFound();
        }

        return Ok(shift);
    }

    [HttpPost]
    public async Task<ActionResult<GetShiftDto>> AddShift(CreateShiftDto createShiftDto)
    {
        var shift = await _shiftService.AddShiftAsync(createShiftDto);
        if (shift is null)
        {
            return BadRequest("Can't create a new shift!");
        }
        return CreatedAtAction(nameof(GetShiftById), new { id = shift.Id }, shift);
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Shift>> UpdateShift(int id, UpdateShiftDto shift)
    {
        var result = await _shiftService.UpdateShiftAsync(id, shift);
        if (result is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteShift(int id)
    {
        var isShiftRemoved = await _shiftService.RemoveShift(id);
        if (isShiftRemoved)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
