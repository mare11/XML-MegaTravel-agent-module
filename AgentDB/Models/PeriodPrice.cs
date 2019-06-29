using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class PeriodPrice
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime StartDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime EndDate { get; set; }

        /// <remarks/>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <remarks/>
        public long Id { get; set; }
    }
}
