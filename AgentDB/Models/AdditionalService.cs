using AgentDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class AdditionalService
    {
        /// <remarks/>
        public string AdditionalServiceName { get; set; }

        /// <remarks/>
        public long Id { get; set; }

    }
}
