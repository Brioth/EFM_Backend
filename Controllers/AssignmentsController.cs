using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFM_Backend.API.Domain.Models;
using EFM_Backend.API.Domain.Services;
using EFM_Backend.API.Extensions;
using EFM_Backend.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public AssignmentsController(IAssignmentService assignmentService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AssignmentResource>> GetAllAsync()
        {
            var assignments = await _assignmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentResource>>(assignments);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.SaveAsync(assignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Assignment);
            return Ok(assignmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var assignment = _mapper.Map<SaveAssignmentResource, Assignment>(resource);
            var result = await _assignmentService.UpdateAsync(id, assignment);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, SaveAssignmentResource>(result.Assignment);
            return Ok(assignmentResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _assignmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var assignmentResource = _mapper.Map<Assignment, AssignmentResource>(result.Assignment);
            return Ok(assignmentResource);
        }
    }
}