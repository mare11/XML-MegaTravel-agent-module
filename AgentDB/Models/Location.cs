using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class Location
    {
        public Location()
        {
            this.Latitude = ((decimal)(0.0m));
            this.Longitude = ((decimal)(0.0m));
        }

        /// <remarks/>
        public string Country { get; set; }

        /// <remarks/>
        public string City { get; set; }

        /// <remarks/>
        public string Address { get; set; }

        /// <remarks/>
        public decimal Latitude { get; set; }

        /// <remarks/>
        public decimal Longitude { get; set; }

        /// <remarks/>
        public long Id { get; set; }

    }
}
