using Microsoft.AspNetCore.Mvc;
using SI.Application.DTO;
using SI.Application.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAccessController : ControllerBase
    {
        private readonly IServiceAccessService _serviceAccessService;

        public ServiceAccessController(IServiceAccessService serviceAccessService)
        {
            _serviceAccessService = serviceAccessService;
        }

        // GET: api/serviceaccess
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accesses = await _serviceAccessService.GetAllAccessesAsync();
            return Ok(accesses);
        }

        // GET: api/serviceaccess/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var access = await _serviceAccessService.GetAccessByIdAsync(id);
            if (access == null)
                return NotFound(new { message = "Service access not found" });
            return Ok(access);
        }

        // GET: api/serviceaccess/service/{serviceId}
        [HttpGet("service/{serviceId}")]
        public async Task<IActionResult> GetByService(int serviceId)
        {
            var accesses = await _serviceAccessService.GetAccessesByServiceIdAsync(serviceId);
            return Ok(accesses);
        }

        // GET: api/serviceaccess/node/{nodeId}
        [HttpGet("node/{nodeId}")]
        public async Task<IActionResult> GetByNode(int nodeId)
        {
            var accesses = await _serviceAccessService.GetAccessesByNodeIdAsync(nodeId);
            return Ok(accesses);
        }

        // POST: api/serviceaccess
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceAccessDto dto)
        {
            try
            {
                var access = await _serviceAccessService.CreateAccessAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = access.Id }, access);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/serviceaccess/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceAccessDto dto)
        {
            try
            {
                var access = await _serviceAccessService.UpdateAccessAsync(id, dto);
                if (access == null)
                    return NotFound(new { message = "Service access not found" });
                return Ok(access);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/serviceaccess/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _serviceAccessService.DeleteAccessAsync(id);
            if (!result)
                return NotFound(new { message = "Service access not found" });
            return Ok(new { message = "Service access deleted successfully" });
        }
    }
}