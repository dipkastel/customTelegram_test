using System;
using System.ComponentModel.DataAnnotations;

namespace FormEngine.Database.Common.Interface
{
    public class Auditable
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Guid DeletedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Guid? OwnerUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}