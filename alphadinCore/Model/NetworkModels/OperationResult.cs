using Microsoft.AspNetCore.Mvc;
using System;

namespace alphadinCore.Model.NetworkModels
{
    public class OperationResult
    {
        public string Status { get; set; }
        public string code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string ResultDate { get; set; }
        public string ErrorStackTrace { get; set; }

        public JsonResult Success(JsonResult data)
        {
            this.Status = StatusType.Success.ToString();
            this.code = "200";
            this.Data = (data!=null)?data.Value:data;
            this.Message = "عملیات با موفقیت انجام شد";
            this.ResultDate = DateTime.Now.ToString();
            return new JsonResult(this);
        }
        public JsonResult Error(string error,string message,string code)
        {
            this.Status = StatusType.Faild.ToString();
            this.code = code;
            this.ErrorStackTrace = error;
            this.Message = message;
            this.ResultDate = DateTime.Now.ToString();
            return new JsonResult(this);
        }
    }
    enum StatusType
    {
        Success,
        Faild
    }
}
