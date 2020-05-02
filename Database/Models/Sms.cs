using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class Sms : Auditable
    {
        


        public int Status { get; set; }
        public string Reciver { get; set; }
        public string Text { get; set; }
        public string Key { get; set; }
        public int SmsType { get; set; }
        public string SmsResult { get; set; }
        public DateTime SendDate { get; set; }

    }
}
