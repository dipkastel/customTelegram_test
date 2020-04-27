using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using alphadinCore.Model.NetworkModels;
using alphadinCore.Model;

namespace alphadinCore.Common.Filters
{
    public class ResultFixer : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(CustomException))
                filterContext.Result = new OperationResult().Error(filterContext.Exception.StackTrace, filterContext.Exception.Message, (filterContext.Exception as CustomException).code);
            else
                filterContext.Result = new OperationResult().Error(filterContext.Exception.Message + "--*--" + filterContext.Exception.StackTrace, "عملیات با خطا مواجه شد","500");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.ModelState.IsValid == false)
                filterContext.Result = new OperationResult().Error("input is not valid", "ورودی معتبر نیست","400");
            else
                filterContext.Result = new OperationResult().Success(filterContext.Result as JsonResult);
        }

    }
}
