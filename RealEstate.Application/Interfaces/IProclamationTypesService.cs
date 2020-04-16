using RealEstate.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IProclamationTypesService
    {
        Task<IEnumerable<ProclamationTypesViewModel>> GetProclamationTypes();
    }
}
