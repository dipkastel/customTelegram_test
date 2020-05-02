using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Common.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Operator;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    [Area("TestterCity")]
    [ApiController]
    public class SchoolController : BaseController
    {
        private readonly SchoolCourseService _courseService;
        private readonly SchoolCourseCertificateService _certificateService;

        public SchoolController(SchoolCourseService courseService, SchoolCourseCertificateService certificateService)
        {
            _courseService = courseService;
            _certificateService = certificateService;
        }


        [HttpGet]
        public JsonResult GetCourses()
        {
            return (JsonResult) _courseService.GetAll().Data;
        }

        [HttpGet]
        public JsonResult GetMyCourse()
        {
            return (JsonResult) _certificateService.GetAllIncluding(c => c.SchoolCourse)
                .Where(certificate => certificate.OwnerUserId == 1);
        }
    }
}