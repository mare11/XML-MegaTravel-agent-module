using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgentDB.Models
{
    public class AdditionalServicesOnly
    {
        public string AdditionalServiceName { get; set; }

        /// <remarks/>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
