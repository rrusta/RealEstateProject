using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProclamationTypesController : ControllerBase
    {
        private readonly IProclamationTypesService _proclamationTypesService;

        public ProclamationTypesController(IProclamationTypesService proclamationTypesService)
        {
            _proclamationTypesService = proclamationTypesService;
        }

        [HttpGet("getProclamationTypes")]
        public async Task<IActionResult> GetProclamationTypes()
        {
            var proclamationTypes = await _proclamationTypesService.GetProclamationTypes();
            return Ok(proclamationTypes);
        }
    }
}