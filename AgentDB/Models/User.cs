using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class User
    {
        public User()
        {
            this.Enabled = false;
            this.Deleted = false;
        }

        /// <remarks/>
        public string Username { get; set; }

        /// <remarks/>
        public string Password { get; set; }

        /// <remarks/>
        public string Email { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string Lastname { get; set; }

        /// <remarks/>
        public bool Enabled { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reservation", Namespace = "https://github.com/mare11/XML_MegaTravel/reservation")]
        public Reservation[] Reservation { get; set; }

        /// <remarks/>
        public bool Deleted { get; set; }

        /// <remarks/>
        public long Id { get; set; }
    }
}
