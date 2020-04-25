using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.smsModels
{
    public class SendSmsResultModel
    {
        public bool success { get; set; }
        public string EnMessage { get; set; }
        public string FaMessage { get; set; }

    }
}
