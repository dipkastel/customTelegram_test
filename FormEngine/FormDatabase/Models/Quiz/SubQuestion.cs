using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models.Quiz
{
    public class SubQuestion : Auditable
    {
        public bool IsMultiple { get; set; }

        public ICollection<Option> Options { get; set; }

    }
}
