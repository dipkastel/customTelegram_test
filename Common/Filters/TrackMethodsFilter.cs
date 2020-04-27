using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;

namespace alphadinCore.Common.Filters
{
    public class TrackMethodsFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = "\n\r"+ filterContext.RouteData.Values["controller"].ToString() + " -> " +
               filterContext.RouteData.Values["action"].ToString() + " -> " +
               filterContext.Exception.Message + " \t- " + DateTime.Now.ToString() + "\n\r";
            LogExecutionTime(message);
            LogExecutionTime("\n\r---------------------------------------------------------\n\r");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "\n\r" + filterContext.RouteData.Values["controller"].ToString() +
                " -> " + filterContext.RouteData.Values["action"].ToString() + " -> OnActionExecuting \t- " +
                DateTime.Now.ToString() + "\n\r";
            LogExecutionTime(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "\n\r" + filterContext.RouteData.Values["controller"].ToString() +
                " -> " + filterContext.RouteData.Values["action"].ToString() + " -> OnActionExecuted \t- " +
                DateTime.Now.ToString() + "\n\r";
            LogExecutionTime(message);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = "\n\r" + filterContext.RouteData.Values["controller"].ToString() +
                " -> " + filterContext.RouteData.Values["action"].ToString() +
                " -> OnResultExecuting \t- " + DateTime.Now.ToString() + "\n\r";
            LogExecutionTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "\n\r" + filterContext.RouteData.Values["controller"].ToString() +
                " -> " + filterContext.RouteData.Values["action"].ToString() +
                " -> OnResultExecuted \t- " + DateTime.Now.ToString() + "\n\r";
            LogExecutionTime(message);
            LogExecutionTime("\n\r---------------------------------------------------------\n\r");
        }


        private void LogExecutionTime(string data) {
            try
            {
            File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods1.txt",data);
            }catch(Exception e)
            {
                try
                {
                    File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods2.txt", data);
                }
                catch (Exception e1)
                {
                    try
                    {
                        File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods3.txt", data);
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods4.txt", data);
                        }
                        catch (Exception e3)
                        {
                            try
                            {
                                File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods5.txt", data);
                            }
                            catch (Exception e4)
                            {
                                try
                                {
                                    File.AppendAllText(Directory.GetCurrentDirectory() + "/Data/TrackMethods6.txt", data);
                                }
                                catch (Exception e5)
                                {


                                }

                            }

                        }

                    }

                }

            }
        
        }
    }
}
