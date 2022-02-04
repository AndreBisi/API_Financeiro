using ApiRestFullAlura.Data.Dtos;
using ApiRestFullAlura.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>();
            CreateMap<UpdateDespesaDto, Despesa>();

        }
    }
}
