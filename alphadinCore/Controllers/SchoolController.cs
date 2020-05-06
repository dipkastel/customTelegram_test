using System.Collections.Generic;
using System.Linq;
using alphadinCore.Common.Controllers;
using alphadinCore.Common.Filters;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using Authentication.Services.Interface;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alphadinCore.Controllers
{
    public class SchoolController : BaseController
    {


        private readonly DbContextModel _db;
        public SchoolController(DbContextModel db, IOnlineUserService onlineUserService) : base(onlineUserService)
        {
            _db = db;
        }



        [HttpGet]
        public JsonResult GetTopics()
        {
            var topics = _db.SchoolTopics.Include(sc=>sc.Courses).ToList();
            return new JsonResult(topics);
        }




        [HttpPost]
        public JsonResult GetCourses(SchoolGetCoursesInput input)
        {
            SchoolTopic topic = _db.SchoolTopics.Include(sc => sc.Courses).FirstOrDefault(o => o.Id == input.TopicId);
            if (topic == null)
                throw new CustomException("چنین تاپیکی وجود ندارد", ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "01");
            List<int> CourseIds = topic.Courses.Select(p=>p.Id).ToList();
            if (CourseIds == null)
                throw new CustomException("درسی برای این تاپیک وارد نشده", ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "02");
            var courses = _db
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