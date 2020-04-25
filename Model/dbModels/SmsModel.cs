using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace alphadinCore.Model
{
    public class SmsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public string Reciver { get; set; }
        public string Text { get; set; }
        public string Key { get; set; }
        public DateTime SendDate { get; set; }

    }

    enum SmsStatus { Success = 0, Faild = 1 }


}
