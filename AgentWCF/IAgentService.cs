using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AgentWCF
{
    [ServiceContract]
    public interface IAgentService
    {
        [OperationContract]
        string Hello();

        [OperationContract]
        string Hi(string name);

        [OperationContract]
        int Sum(int a, int b);
    }
}
