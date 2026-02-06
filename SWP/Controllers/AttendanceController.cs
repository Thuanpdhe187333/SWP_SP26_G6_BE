using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP.BLL.IService;
using System.Security.Claims;

namespace SWP.Controllers
{
    [ApiController]
    [Route("api/attendance")]
    [Authorize] // Yêu cầu đăng nhập
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// Ghi nhận check-in hoặc check-out (tự động xác định)
        /// </summary>
        [HttpPost("check")]
        public IActionResult Check()
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = _attendanceService.Check(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Lấy trạng thái chấm công hôm nay
        /// </summary>
        [HttpGet("today")]
        public IActionResult GetTodayAttendance()
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = _attendanceService.GetTodayAttendance(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Lấy UserId từ JWT token
        /// </summary>
        private string GetCurrentUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new Exception("Không tìm thấy thông tin người dùng");
            return userId;
        }
    }
}
