using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class UserLanguageModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public UserModel user { get; set; }
        public int LanguageId { get; set; }
        public int ReadingRate { get; set; }
        public int WritingRate { get; set; }
        public int SpeakingRate { get; set; }
    }
}
