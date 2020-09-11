using EventsBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsBack.Core.Interfaces
{
    public interface IVisitorsRepository
    {       
        Task<IEnumerable<Visitas>> GetVisitors();
        Task NewVisitor(Visitas visita);
    }
}
