using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKBase.Models;

namespace MKBase.Service.ContextService
{
    public interface IContextService
    {
        int GetCurrentUserId();
        User GetCurrentUser();
    }
}