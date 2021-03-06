﻿using System;
using FormEngine.Database.Models;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator.Interface
{
    public interface IFormService : IGenericRepository<Form>
    {
        string GetFormHtml(Guid formId);
    }
}