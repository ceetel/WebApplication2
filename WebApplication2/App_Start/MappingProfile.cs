using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.SS.Formula;
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
                // Domain to Dto
                cfg.CreateMap<CustomerModels, CustomerDto>();
                // just need map from model to dto.
                cfg.CreateMap<MembershipTypeModels, MembershipTypeDto>();
                cfg.CreateMap<BookModels, BookDto>();
                

                // Dto to Domain
                cfg.CreateMap<CustomerDto, CustomerModels>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<BookDto, BookModels>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
            });
        }
    }
}