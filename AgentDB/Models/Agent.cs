using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace AgentApp.Models
{
    public class Agent
    {

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
        public string Adress { get; set; }

        /// <remarks/>
        public int BussinesID { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Accommodation", Namespace = "https://github.com/mare11/XML_MegaTravel/accommodation")]
        public Accommodation[] Accommodation { get; set; }

        /// <remarks/>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
