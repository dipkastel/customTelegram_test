using System;

namespace alphadinCore.Model
{
    public class CustomException : Exception
    {
        public string code { get; set; }
        public CustomException(string message,string _code):base(message) {
            code = _code;
        }



    }
}
