using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class Message
    {

        /// <remarks/>
        public string Content { get; set; }

        /// <remarks/>
        public System.DateTime Timestamp { get; set; }

        /// <remarks/>
        public DirectionEnum Direction { get; set; }

        /// <remarks/>
        public long Id { get; set; }
    }
}
