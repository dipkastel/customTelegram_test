using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Areas.TesterCity.Common;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Operator.Interfaces;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    public class QuizController : TesterCityController
    {
        private readonly ISchoolQuizQuestionService _questionService;
        private readonly ISchoolQuisQuestionOptionService _questionOptionService;
        private readonly ISchoolQuizCourseService _quizCourseService;

        public QuizController(IOnlineUserService onlineUserService, ISchoolQuizQuestionService questionService,
            ISchoolQuisQuestionOptionService questionOptionService, ISchoolQuizCourseService quizCourseService) 
            : base(onlineUserService)
        {
            _questionService = questionService;
            _questionOptionService = questionOptionService;
            _quizCourseService = quizCourseService;
        }



    }
}