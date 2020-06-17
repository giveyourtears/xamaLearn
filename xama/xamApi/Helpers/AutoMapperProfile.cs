using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using xamApi.Models;
﻿using AutoMapper;

namespace xamApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<UserModel, User>();
      CreateMap<RegisterModel, UserModel>();
      CreateMap<UpdateModel, UserModel>();
    }
  }
}
