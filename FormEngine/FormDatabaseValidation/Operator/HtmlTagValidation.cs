﻿using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.DatabaseValidation.Structure;

namespace FormEngine.DatabaseValidation.Operator
{
    public class HtmlTagValidation : GenericValidation<HtmlTag>, IHtmlTagValidation
    {
        public HtmlTagValidation(FormEngineDbContext context) : base(context)
        {
        }
    }
}