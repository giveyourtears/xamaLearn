<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using xamApi.Models;

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
