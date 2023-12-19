using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.App_Start
{
    public class MappingProfile
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerModels, CustomerDto>();
                cfg.CreateMap<CustomerDto, CustomerModels>();
            });
        }
    }
}