using AgentApp.Models;
using AgentDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgentServicesDB
{
    public class AgentAccommodationService : IAgentAccommodation
    {
        private AgentContext _context;

        public AgentAccommodationService(AgentContext context)
        {
            _context = context;
        }

        public void Add(Accommodation newAccommodation)
        {
            _context.Add(newAccommodation);
            _context.SaveChanges();
        }

        public IEnumerable<Accommodation> GetAll()
        {
            return _context.Accommodations;
        }

        public Accommodation GetById(long id)
        {
            return _context.Accommodations
                .FirstOrDefault(Accommodation => Accommodation.Id == id);
        }
    }
}
