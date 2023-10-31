using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Dtos.Project;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllProjectDto>>> GetProjects()
        {
           var projects = await _projectRepository.GetAllAsync();
            if (projects == null)
            {
                return NotFound();
            }

           var records = _mapper.Map<List<GetAllProjectDto>>(projects);

           return Ok(records);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProjectDto>> GetProject(int id)
        {
          var project = await _projectRepository.GetProjectDetails(id);

            if (project == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetProjectDto>(project);

            return Ok(record);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id)
            {
                return BadRequest("Invalid Record Id");
            } 

            var project = await _projectRepository.GetAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            _mapper.Map(updateProjectDto, project);

            try
            {
                await _projectRepository.UpdateAsync(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(CreateProjectDto createProjectDto)
        {
            var project = _mapper.Map<Project>(createProjectDto);

            await _projectRepository.AddAsync(project);

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            await _projectRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ProjectExists(int id)
        {
            return await _projectRepository.Exists(id);
        }

        [HttpPost("{projectId}/assignTask")]
        public async Task<ActionResult> AssignTaskToProject(int projectId, int taskId)
        {
            var project = await _projectRepository.AssignTaskToProject(projectId, taskId);
            if (project == null)
            {
                return NotFound("Project or task not found"); 
            }
            return Ok("Task assigned to the project successfully.");
        }

        [HttpDelete("{projectId}/removeTask")]
        public async Task<ActionResult> RemoveTaskFromProject(int projectId, int taskId)
        {
            var project = await _projectRepository.RemoveTaskFromProject(projectId, taskId);
            if (project == null)
            {
                return NotFound("Project or task not found");
            }  
            return Ok("Task removed from the project successfully.");
        }
    }
}
