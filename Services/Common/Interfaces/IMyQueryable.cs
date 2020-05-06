using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Common.Interfaces
{
    public interface IMyQueryable<out T> : IQueryable<T>
    {
    }
}