using System;
using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace Database.Common.Interfaces
{
    public abstract class Auditable
    {
        [Key]
        public virtual int Id { get; set; }

        public int Status { get; set; }

        public int? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int? OwnerUserId { get; set; }

        public bool IsDeleted { get; set; }


        #region Relations

        //public User CreatedByUser { get; set; }
        //public User UpdatedByUser { get; set; }
        //public User DeletedByUser { get; set; }
        //public User OwnerUser { get; set; }

        #endregion
    }
}