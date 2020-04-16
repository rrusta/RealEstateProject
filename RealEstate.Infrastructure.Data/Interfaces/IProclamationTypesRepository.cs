using RealEstate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data.Interfaces
{
    public interface IProclamationTypesRepository
    {
        Task<IEnumerable<ProclamationTypes>> GetProclamationTypes();
    }
}
