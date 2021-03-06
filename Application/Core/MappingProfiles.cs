using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Application.Activities;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        //map one obj from another obj
        public MappingProfiles(){
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
            .ForMember(d => d.HostUsername, o=> o.MapFrom(s => s.Attendees
                .FirstOrDefault(x => x.isHost).AppUser.UserName));

            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o=> o.MapFrom(s=>s.AppUser.DisplayName))
                .ForMember(d => d.Username, o=> o.MapFrom(s=>s.AppUser.UserName))
                .ForMember(d => d.Bio, o=> o.MapFrom(s=>s.AppUser.Bio));
        }
    }
}