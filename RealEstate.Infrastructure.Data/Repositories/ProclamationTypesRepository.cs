using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Context;
using RealEstate.Domain.Models;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data.Repositories
{
    public class ProclamationTypesRepository : IProclamationTypesRepository
    {
        private readonly RealEstateDBContext _ctx;

        public ProclamationTypesRepository(RealEstateDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ProclamationTypes>> GetProclamationTypes()
        {
            return await _ctx.ProclamationTypes.ToListAsync();
        }
    }
}
