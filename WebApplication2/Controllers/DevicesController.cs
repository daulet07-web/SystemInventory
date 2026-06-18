using Microsoft.AspNetCore.Mvc;
using SI.Application.DTO;
using SI.Application.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // GET: api/devices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices);
        }

        // GET: api/devices/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound(new { message = "Device not found" });
            return Ok(device);
        }

        // POST: api/devices
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceDto dto)
        {
            try
            {
                var device = await _deviceService.CreateDeviceAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/devices/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDeviceDto dto)
        {
            try
            {
                var device = await _deviceService.UpdateDeviceAsync(id, dto);
                if (device == null)
                    return NotFound(new { message = "Device not found" });
                return Ok(device);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/devices/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deviceService.DeleteDeviceAsync(id);
            if (!result)
                return NotFound(new { message = "Device not found" });
            return Ok(new { message = "Device deleted successfully" });
        }
    }
}