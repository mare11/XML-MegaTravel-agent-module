using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class ReservationRating
    {
        public ReservationRating()
        {
            this.Published = false;
        }

        /// <remarks/>
        public int Rating { get; set; }

        /// <remarks/>
        public string Comment { get; set; }

        /// <remarks/>
        public System.DateTime Timestamp { get; set; }

        /// <remarks/>
        public bool Published { get; set; }

        /// <remarks/>
        public long Id { get; set; }
    }
}
