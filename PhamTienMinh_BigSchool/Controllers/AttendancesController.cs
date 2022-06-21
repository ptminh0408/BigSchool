using Microsoft.AspNet.Identity;
using PhamTienMinh_BigSchool.DTOs;
using PhamTienMinh_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhamTienMinh_BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext dbContext;
        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var uerId = User.Identity.GetUserId();
            if (dbContext.Attendances.Any(a => a.AttendeeId == uerId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendence alrealy exists");
            var attendace = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()
            };

            dbContext.Attendances.Add(attendace);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
