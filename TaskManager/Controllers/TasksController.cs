using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Dtos.Tasks;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            this._taskRepository = taskRepository;
            this._mapper = mapper;
        }

        // GET: api/Tasks

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllTasksDto>>> GetTasks()
        {
           var tasks = await _taskRepository.GetAllAsync();

          if (tasks == null)
          {
              return NotFound();
          }
            var records = _mapper.Map<List<GetAllTasksDto>>(tasks);

            return Ok(records);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskDto>> GetTask(int id)
        {
            var task = await _taskRepository.GetAsync(id);

              if (task == null)   
              {
                  return NotFound();
              }

            var record = _mapper.Map<GetTaskDto>(task);

            return Ok(record);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, UpdateTaskDto updateTaskDto)
        {
            if (id != updateTaskDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(updateTaskDto, task);

            try
            { 
                await _taskRepository.UpdateAsync(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await TasksExists(id))
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

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTasks(CreateTaskDto createTaskDto)
        {
            var task = _mapper.Map<Tasks>(createTaskDto);

            await _taskRepository.AddAsync(task);

            return CreatedAtAction("GetTasks", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            await _taskRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TasksExists(int id)
        {
            return await _taskRepository.Exists(id);
        }
         
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<GetTaskDto>>> GetTasksOnStatus(string status)
        {
            var tasks = await _taskRepository.GetTasksBasedOnStatus(status);

            if (tasks == null)
            {
                return NotFound();
            }
           var records = _mapper.Map<List<GetTaskDto>>(tasks);

            return Ok(records);
        }

        [HttpGet("currentweek")]
        public async Task<ActionResult<IEnumerable<GetTaskDto>>> GetTasksInCurrentWeek()
        {
            var tasks = await _taskRepository.GetTasksBasedOnCurrentWeek();
            if (tasks == null)
            {
                return NotFound();
            }
            var records = _mapper.Map<List<GetTaskDto>>(tasks);

            return Ok(records);
        }
    }
}