using System;

namespace alphadinCore.Model
{
    public class CustomException : Exception
    {
        public string Code { get; set; }

        public CustomException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}
