using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AgentWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AgentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AgentService.svc or AgentService.svc.cs at the Solution Explorer and start debugging.
    public class AgentService : IAgentService
    {

        public string Hello()
        {
            return "Hello Nikola";
        }

        public string Hi(string name)
        {
            return "Hi " + name;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
