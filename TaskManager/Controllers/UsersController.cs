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
using TaskManager.Dtos.User;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllUsersDto>>> GetUsers()
        {
          var users = await _userRepository.GetAllAsync();
          if (users == null)
          {
              return NotFound();
          }
            var records = _mapper.Map<List<GetAllUsersDto>>(users);
            return Ok(records);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
              var user = await _userRepository.GetUserDetails(id);
          
              if (user == null)
              {
                  return NotFound();
              }

            var record = _mapper.Map<GetUserDto>(user);
            return Ok(record);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
         
        public async Task<IActionResult> PutUser(int id, UpdateUserDto updateUserDto)
        {

            if (id == updateUserDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }
            var user = await _userRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(updateUserDto, user);
             
            try
            {
                await _userRepository.UpdateAsync(user); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            
            await _userRepository.AddAsync(user);
       
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
           return await _userRepository.Exists(id);
        }
    }
}
