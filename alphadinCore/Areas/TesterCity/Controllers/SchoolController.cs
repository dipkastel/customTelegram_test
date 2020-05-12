using System;
using System.Collections.Generic;
using System.Linq;
using alphadinCore.Areas.TesterCity.Common;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using Authentication.Services.Interface;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Operator.Interfaces;
using Services.Operator.School.Interfaces;
using Services.ViewModels.School;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    public class SchoolController : TesterCityController
    {
        private readonly ISchoolTopicService _topicService;
        private readonly ISchoolCourseService _courseService;
        private readonly ISchoolUnitService _unitService;
        private readonly ISchoolUserUnitReadService _unitReadService;

        public SchoolController(ISchoolCourseService courseService, ISchoolTopicService topicService, IOnlineUserService onlineUserService, ISchoolUserUnitReadService unitReadService, ISchoolUnitService unitService): base(onlineUserService)
        {
            _courseService = courseService;
            _topicService = topicService;
            _unitReadService = unitReadService;
            _unitService = unitService;
        }

        [HttpGet]
        public JsonResult Topics()
        {
            var topicResult = _topicService.GetAll();

            if (!topicResult.Success || !topicResult.Data.Any())
            {
                throw new CustomException("موضوع وجود ندارد",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_TOPICS + "01");
            }
            
            IList<SchoolTopicViewModel> result = new List<SchoolTopicViewModel>();
            foreach (var topic in topicResult.Data)
            {
                result.Add(new SchoolTopicViewModel(topic.ImageUrl, topic.Title, topic.Description));
            }

            return new JsonResult(result);
        }

        [HttpGet]
        public JsonResult Courses(SchoolGetCoursesInput input)
        {
            var topic = _topicService.GetAllIncluding(sc => sc.Courses)
                .FirstOrDefault(o => o.Id == input.TopicId);

            if (topic == null)
                throw new CustomException("چنین موضوعی وجود ندارد",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "01");

            var courseIds = topic.Courses.Select(p => p.Id).ToList();

            if (courseIds == null)
                throw new CustomException("درسی برای این موضوعی وارد نشده",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_COURSES + "02");

            var courses = _courseService.GetAllIncluding(sc => sc.Units)
                .Where(o => courseIds.Contains(o.Id))
                .Select(sc => new SchoolCourseViewModel(sc.Id,
                    sc.Title,
                    sc.ReadTime,
                    sc.Units))
                .ToList();

            return new JsonResult(courses);

        }

        [HttpGet]
        public JsonResult Units(SchoolGetUnitsInput input)
        {
            var units = _unitService.FindBy(u => u.CourseId == input.CourseId);

            if (units.Success && units.Data.Any())
                return new JsonResult(units.Data);

            if (_courseService.Get(input.CourseId).Data == null)
            {
                throw new CustomException("چنین کورسی وجود ندارد",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_UNITS + "01");
            }

            throw new CustomException("درسی برای این کورس وارد نشده",
                ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_GET_UNITS + "02");
        }

        [HttpGet]
        public JsonResult LastUnit(SchoolGetLastUnitInput input)
        {
            var user = GetUser(HttpContext);

            var lastUnit = _unitReadService
                .FindBy(lu => lu.CourseId == input.CourseId && lu.OwnerUserId == user.Id).Data
                .OrderByDescending(lu => lu.UnitId)
                .FirstOrDefault();

            return lastUnit == null ? null : new JsonResult(lastUnit.UnitId);
        }

        [HttpGet]
        public JsonResult ReadPercentage(SchoolGetLastUnitInput input)
        {
            var user = GetUser(HttpContext);

            var lastRead = _unitReadService
                .GetAllIncluding(ur => ur.Unit)
                .Where(lu => lu.CourseId == input.CourseId && lu.OwnerUserId == user.Id)
                .OrderByDescending(lu => lu.UnitId)
                .FirstOrDefault();

            if (lastRead == null)
            {
                return new JsonResult(0);
            }

            var unitsCount = _unitService.GetUnitsCount(input.CourseId);

            var percentage = (lastRead.Unit.PageNumber * 100) / unitsCount;

            return new JsonResult(percentage);
        }

        [HttpGet]
        //[ResponseCache(Duration = 3600, NoStore = false, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new []{"*"})]
        public JsonResult UnitCount(SchoolGetLastUnitInput input)
        {
            var unitsCount = _unitService.GetUnitsCount(input.CourseId);
            return new JsonResult(unitsCount);
        }

        [HttpPost]
        public JsonResult PassUnit(SchoolSetLastUnitInput input)
        {
            var user = GetUser(HttpContext);

            var userLastUnit = new SchoolUserUnitRead()
            {
                CourseId = input.CourseId,
                UnitId = input.UnitId
            };

            var insertResult = _unitReadService.Add(userLastUnit, user.Id);

            if (insertResult.Success)
            {
                return new JsonResult("DONE");
            }

            var unit = _unitService.Find(c => c.Id == input.UnitId);

            if (!unit.Success && unit.Data == null)
            {
                throw new CustomException("چنین صفحه ای وجود ندارد",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_SET_LAST_UNIT + "01");
            }

            if (unit.Data.CourseId != input.CourseId)
            {
                throw new CustomException("حطا در ارسال اطلاعات",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_SET_LAST_UNIT + "02");
            }

            var course = _courseService.Find(c => c.Id == input.CourseId);

            if (!course.Success && course.Data == null)
            {
                throw new CustomException("چنین کورسی وجود ندارد",
                    ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_SET_LAST_UNIT + "03");
            }

            throw new CustomException("خطا در ثبت اطلاعات",
                ErrorsPreFix.CONTROLLER_SCHOOL + ERROR_SET_LAST_UNIT + "04");
        }

        private string ERROR_GET_TOPICS = "01";
        private string ERROR_GET_COURSES = "02";
        private string ERROR_GET_UNITS = "03";
        private string ERROR_SET_LAST_UNIT = "04";

    }
}