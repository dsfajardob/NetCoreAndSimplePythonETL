using EventsBack.Core.Entities;
using EventsBack.Core.Interfaces;
using EventsBack.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsBack.Infraestructure.Repositories
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private readonly Prueba_12Context _context;

        public VisitorsRepository(Prueba_12Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visitas>> GetVisitors()
        {
            var visitors = await _context.Visitas.ToListAsync();
            return visitors;
        }

        public async Task NewVisitor(Visitas visita)
        {
            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();
        }
    }
}
