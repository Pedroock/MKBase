using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKBase.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MKBase.Models;

namespace MKBase.Service.ContextService
{
    public class ContextService : IContextService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public ContextService(DataContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public int GetCurrentUserId() => int.Parse(
            _httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );
        public User GetCurrentUser() => _context.Users.FirstOrDefault(u => u.Id == GetCurrentUserId())!;
    }
}