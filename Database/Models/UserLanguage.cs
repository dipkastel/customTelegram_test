using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserLanguage : Auditable
    {
        
        
        public int Status { get; set; }
        public User User { get; set; }
        public int LanguageId { get; set; }
        public int ReadingRate { get; set; }
        public int WritingRate { get; set; }
        public int SpeakingRate { get; set; }
    }
}
