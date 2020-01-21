using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<OwnerForCreationDTO, Owner>();
            CreateMap<OwnerForUpdateDTO, Owner>();
        }
    }
}
