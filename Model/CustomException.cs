using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
