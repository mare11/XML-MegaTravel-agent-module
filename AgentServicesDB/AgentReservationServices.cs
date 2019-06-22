using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgentApp.Models;
using AgentDB;

namespace AgentServicesDB
{
    public class AgentReservationServices : IAgentReservation
    {
        private AgentContext _context;

        public AgentReservationServices(AgentContext context)
        {
            _context = context;
        }

        public Reservation GetByIdMainDB(long id)
        {
            return _context.Reservations
                .FirstOrDefault(Reservation => Reservation.Id == id);
        }
    }
}
