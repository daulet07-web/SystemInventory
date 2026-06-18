using Microsoft.AspNetCore.Mvc;
using SI.Application.DTO;
using SI.Application.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeService _nodeService;

        public NodesController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        // GET: api/nodes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nodes = await _nodeService.GetAllNodesAsync();
            return Ok(nodes);
        }

        // GET: api/nodes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var node = await _nodeService.GetNodeByIdAsync(id);
            if (node == null)
                return NotFound(new { message = "Node not found" });
            return Ok(node);
        }

        // POST: api/nodes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNodeDto dto)
        {
            try
            {
                var node = await _nodeService.CreateNodeAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = node.Id }, node);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/nodes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateNodeDto dto)
        {
            try
            {
                var node = await _nodeService.UpdateNodeAsync(id, dto);
                if (node == null)
                    return NotFound(new { message = "Node not found" });
                return Ok(node);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/nodes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _nodeService.DeleteNodeAsync(id);
            if (!result)
                return NotFound(new { message = "Node not found" });
            return Ok(new { message = "Node deleted successfully" });
        }
    }
}