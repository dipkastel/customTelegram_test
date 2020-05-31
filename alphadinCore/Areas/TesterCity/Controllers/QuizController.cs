using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Areas.TesterCity.Common;
using Authentication.Services.Interface;
using FormEngine.Services.Operator.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Operator.Interfaces;
using Services.Operator.Queue.Interface;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    public class QuizController : TesterCityController
    {
        private readonly IQueueService _queueService;
        private readonly IFormService _formService;

        public QuizController(IOnlineUserService onlineUserService, IFormService formService, IQueueService queueService) 
            : base(onlineUserService)
        {
            _formService = formService;
            _queueService = queueService;
        }

        [HttpGet]
        public JsonResult Get(int quizId)
        {
            var formId = Guid.NewGuid(); // TODO: Get quiz's form Id

            return new JsonResult(_formService.GetFormHtml(formId));
        }

        [HttpPost]
        public JsonResult Post([FromBody]string form, int quizId)
        {
            var userId = GetCurrentUserInfo(HttpContext).User.Id;
            _queueService.Insert(form, userId, quizId);

            //TODO: insert html quiz data from queue
            throw new NotImplementedException();
        }

    }
}