using System.Collections.Generic;
using System.Linq;
using alphadinCore.Common.Filters;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alphadinCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TrackMethodsFilter]
    [ResultFixer]
    public class SchoolController : ControllerBase
    {


        private DbContextModel db;
        public SchoolController(DbContextModel _db)
        {
            db = _db;
        }



        [Route("GetTopics")]
        [HttpGet]
        //[Authorize(Roles = "tester")]
        public JsonResult GetTopics()
        {
            List<SchoolTopic> topics = db.SchoolTopics.Include(sc=>sc.Courses).ToList();
            return new JsonResult(topics);
        }




        [Route("GetCourses")]
        [HttpPost]
        //[Authorize(Roles = "tester")]
        public JsonResult GetCourses(SchoolGetCoursesInput input)
        {
            SchoolTopic topic = db.SchoolTopics.Include(sc => sc.Courses).Where(o => o.Id == input.TopicId).FirstOrDefault();
            if (topic == null)
                throw new CustomException("چنین تاپیکی وجود ندارد", ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "01");
            List<int> CourseIds = topic.Courses.Select(p=>p.Id).ToList();
            if (CourseIds == null)
                throw new CustomException("درسی برای این تاپیک وارد نشده", ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "02");
            var courses = db
                .SchoolCourses
                .Include(sc => sc.Units)
                .Where(o => CourseIds.Contains(o.Id))
                .Select(f=>new {
                    Id = f.Id,
                    Title = f.Title,
                    ReadTime=f.ReadTime,
                    Units = f.Units
            } ).ToList();
            return new JsonResult(courses);
        }


        private string ERROR_GET_TOPICS = "01";
        private string ERROR_GET_COURSES = "02";

    }
}