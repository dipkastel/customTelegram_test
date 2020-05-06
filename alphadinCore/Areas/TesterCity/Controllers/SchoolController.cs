using System;
using System.Collections.Generic;
using System.Linq;
using alphadinCore.Areas.TesterCity.Common;
using Authentication.Services.Interface;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Operator.Interfaces;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    public class SchoolController : TesterCityController
    {
        private readonly ISchoolCourseService _courseService;
        private readonly ISchoolTopicService _topicService;

        public SchoolController(ISchoolCourseService courseService, ISchoolTopicService topicService, IOnlineUserService onlineUserService): base(onlineUserService)
        {
            _courseService = courseService;
            _topicService = topicService;
        }

        [HttpGet]
        public JsonResult Topics()
        {
            var topicsResult = _topicService.GetAll();

            return (JsonResult) topicsResult.Data;
        }

        [HttpGet]
        public JsonResult Courses(int topicId)
        {
            return (JsonResult) _topicService
                .GetAllIncluding(t => t.Courses)
                .Where(t => t.Id == topicId)
                .Select(t => t.Courses);
        }

        [HttpGet]
        public JsonResult Units(int courseId)
        {
            return (JsonResult)_courseService
                .GetAllIncluding(c => c.Units)
                .Where(c => c.Id == courseId)
                .Select(c => c.Units);
        }

        [HttpPost]
        public JsonResult PassUnit(int unitId)
        {
            throw new NotImplementedException("گرفتن شماره آخرین یونیت خوانده شده");
        }

        [HttpGet]
        public JsonResult QuizLink(int courseId)
        {
            throw new NotImplementedException("لینک امتحان یک کورسی که تمام شده ولی این آزمون را ندیده");
        }

    }
}