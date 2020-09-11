using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsBack.Core.Entities;
using EventsBack.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsRepository _visitorsRepository;
        public VisitorsController(IVisitorsRepository visitorsRepository)
        {
            _visitorsRepository = visitorsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVisitors()
        {
            var visitors = await _visitorsRepository.GetVisitors();
            return Ok(visitors);
        }

        [HttpPost]
        public async Task<IActionResult> NewVisitor(Visitas visita)
        {
            await _visitorsRepository.NewVisitor(visita);
            return Ok(visita);
        }
    }
}
