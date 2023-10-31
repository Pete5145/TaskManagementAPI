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
using TaskManager.Dtos.Notification;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationRepository notificationRepository, IMapper mapper)
        {
            this._notificationRepository = notificationRepository;
            this._mapper = mapper;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllNotificationsDto>>> GetNotifications()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            
            if (notifications == null)
            {
                return NotFound();
            }
            var records = _mapper.Map<List<GetAllNotificationsDto>>(notifications);

            return Ok(records);
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetNotificationDto>> GetNotification(int id)
        { 
          var notification = await _notificationRepository.GetAsync(id);

          if (notification == null)
          {
              return NotFound();
          }
            var record = _mapper.Map<GetNotificationDto>(notification);
            
            return Ok(record);
        }

        // PUT: api/Notifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            if (id != updateNotificationDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var notification = await _notificationRepository.GetAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            _mapper.Map(updateNotificationDto, notification);

            try
            {
                await _notificationRepository.UpdateAsync(notification);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await NotificationExists(id))
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

        // POST: api/Notifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = _mapper.Map<Notification>(createNotificationDto);
            
            await _notificationRepository.AddAsync(notification);

            return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _notificationRepository.GetAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            await _notificationRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> NotificationExists(int id)
        {
            return await _notificationRepository.Exists(id);
        }

        [HttpPut("{id}/mark-as-read")]
        public async Task<ActionResult> MarkNotificationAsRead(int id)
        {
            var notification = await _notificationRepository.MarkNotificationAsRead(id);

            if (notification == null)
            {
                return NotFound("Notification is not found");
            }

            return Ok("Notification marked as read");
        }

        [HttpPut("{id}/mark-as-unread")]
        public async Task<ActionResult> MarkNotificationAsUnRead(int id)
        {
            var notification = await _notificationRepository.MarkNotificationAsUnRead(id);

            if (notification == null)
            {
                return NotFound("Notification is not found");
            }

            return Ok("Notification marked as unread");
        }
    }
}
