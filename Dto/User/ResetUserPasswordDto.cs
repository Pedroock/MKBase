using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Dto.User
{
    public class ResetUserPasswordDto
    {
        public string currentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}