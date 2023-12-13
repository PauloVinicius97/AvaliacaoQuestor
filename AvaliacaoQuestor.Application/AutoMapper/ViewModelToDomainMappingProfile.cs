using AutoMapper;
using AvaliacaoQuestor.Application.ViewModels;
using AvaliacaoQuestor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BancoPostViewModel, Banco>();
            CreateMap<BoletoPostViewModel, Boleto>();
        }
    }
}
