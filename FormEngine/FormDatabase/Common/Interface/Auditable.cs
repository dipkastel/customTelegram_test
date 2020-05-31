using System;
using System.ComponentModel.DataAnnotations;

namespace FormEngine.Database.Common.Interface
{
    public class Auditable
    {
        [Key]
        public Guid Id { get; set; }

        public int? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int? OwnerUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}