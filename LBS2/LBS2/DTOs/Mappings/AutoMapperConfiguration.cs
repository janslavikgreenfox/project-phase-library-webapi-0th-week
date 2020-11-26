using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBS2.DTOs.Responses;
using LBS2.Entities;

namespace LBS2.DTOs.Mappings
{
    public class AutoMappersDef : AutoMapper.Profile 
    {
        public AutoMappersDef()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<Account, AccountResponse>();
        }
    }
}
