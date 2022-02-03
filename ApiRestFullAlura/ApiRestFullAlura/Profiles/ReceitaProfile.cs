using ApiRestFullAlura.Data.Dtos;
using ApiRestFullAlura.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<CreateReceitaDto, Receita>();
            CreateMap<ReceitaProfile, ReadReceitaDto>();
            CreateMap<UpdateReceitaDto, Receita>();

        }
    }
}
