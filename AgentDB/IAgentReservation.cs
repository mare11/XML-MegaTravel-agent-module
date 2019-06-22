using AgentApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgentDB
{
    public interface IAgentReservation
    {
        Reservation GetByIdMainDB(long id);
    }
}
