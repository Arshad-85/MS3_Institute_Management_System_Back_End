using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS3_Back_End.DTOs.RequestDTOs.ContactUs;
using MS3_Back_End.DTOs.RequestDTOs.Notification;
using MS3_Back_End.Entities;
using MS3_Back_End.IService;
using MS3_Back_End.Service;

namespace MS3_Back_End.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationRequest requestDTO)
        {
            try
            {
                var message = await _notificationService.AddNotification(requestDTO);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAllNotification(Guid studentId)
        {
            try
            {
                var result = await _notificationService.GetAllNotification(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Read/{id}")]
        public async Task<IActionResult> ReadNotification(Guid id)
        {
            var response = await _notificationService.ReadNotification(id);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            try
            {
                var respose = await _notificationService.DeleteNotification(id);
                return Ok(respose);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
