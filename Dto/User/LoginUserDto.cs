using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Dto.User
{
    public class LoginUserDto
    {
        public string UsernameOrEmail {get;set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}