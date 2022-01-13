using AutoMapper;
using Restaurant_Management_Task.Dtos;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.profiles
{
    public class reservationProfiles: Profile
    {
        public reservationProfiles()
        {
            // source -> Target
            CreateMap<reservation, reservationReadDto>();
            CreateMap<reservationCreateDto, reservation>();
            CreateMap<reservationUpdateDto, reservation>();
            CreateMap<UserRegisterDto,User>();
            CreateMap<UserLoginDto,User>();
        }
    }
}
