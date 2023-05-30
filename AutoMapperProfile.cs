using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MKBase.Dtos.User;
using MKBase.Models;

namespace MKBase
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<x, y>();
            CreateMap<User, GetUserDto>();
        }
    }
}