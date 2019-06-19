using AgentApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgentDB
{
    public interface IAgentAccommodation
    {
        IEnumerable<Accommodation> GetAll();
        Accommodation GetById(long id);
        void Add(Accommodation newAccommodation);

    }
}
