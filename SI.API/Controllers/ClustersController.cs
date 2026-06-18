using Microsoft.AspNetCore.Mvc;
using SI.Application.DTO;
using SI.Application.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClustersController : ControllerBase
    {
        private readonly IClusterService _clusterService;

        public ClustersController(IClusterService clusterService)
        {
            _clusterService = clusterService;
        }

        // GET: api/clusters
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clusters = await _clusterService.GetAllClustersAsync();
            return Ok(clusters);
        }

        // GET: api/clusters/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cluster = await _clusterService.GetClusterByIdAsync(id);
            if (cluster == null)
                return NotFound(new { message = "Cluster not found" });
            return Ok(cluster);
        }

        // GET: api/clusters/{id}/nodes
        [HttpGet("{id}/nodes")]
        public async Task<IActionResult> GetNodes(int id)
        {
            var nodes = await _clusterService.GetNodesByClusterIdAsync(id);
            return Ok(nodes);
        }

        // POST: api/clusters
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClusterDto dto)
        {
            try
            {
                var cluster = await _clusterService.CreateClusterAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = cluster.Id }, cluster);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/clusters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClusterDto dto)
        {
            try
            {
                var cluster = await _clusterService.UpdateClusterAsync(id, dto);
                if (cluster == null)
                    return NotFound(new { message = "Cluster not found" });
                return Ok(cluster);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/clusters/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _clusterService.DeleteClusterAsync(id);
                if (!result)
                    return NotFound(new { message = "Cluster not found" });
                return Ok(new { message = "Cluster deleted successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}