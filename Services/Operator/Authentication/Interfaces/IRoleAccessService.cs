﻿using Database.Models.Authentication;
using Services.Repository;

namespace Services.Operator.Authentication.Interfaces
{
    public interface IRoleAccessService : IGenericRepository<RoleAccess>
    {
       
    }
}
