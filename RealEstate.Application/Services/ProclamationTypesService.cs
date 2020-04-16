using AutoMapper;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class ProclamationTypesService : IProclamationTypesService
    {
        private readonly IMapper _autoMapper;
        private readonly IProclamationTypesRepository _repo;

        public ProclamationTypesService(IMapper autoMapper, IProclamationTypesRepository repo)
        {
            _autoMapper = autoMapper;
            _repo = repo;
        }
        public async Task<IEnumerable<ProclamationTypesViewModel>> GetProclamationTypes()
        {
            return _autoMapper.Map<IEnumerable<ProclamationTypesViewModel>>(await _repo.GetProclamationTypes());
        }
    }
}
