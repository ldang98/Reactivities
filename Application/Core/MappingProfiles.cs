using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        //map one obj from another obj
        public MappingProfiles(){
            CreateMap<Activity, Activity>();
        }
    }
}