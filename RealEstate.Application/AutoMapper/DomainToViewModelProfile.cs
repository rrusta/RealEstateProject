using AutoMapper;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<ProclamationTypes, ProclamationTypesViewModel>();
        }
    }
}
