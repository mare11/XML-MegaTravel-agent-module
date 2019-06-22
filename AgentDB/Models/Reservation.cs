using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    public class Reservation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "https://github.com/mare11/XML_MegaTravel/accommodation")]
        public Accommodation Accommodation { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "https://github.com/mare11/XML_MegaTravel/user")]
        public long UserID { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime StartDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime EndDate { get; set; }

        /// <remarks/>
        public bool Realized { get; set; }

        /// <remarks/>
        public ReservationRating ReservationRating { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Message")]
        public List<Message> Messages { get; set; }

        /// <remarks/>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        //public long IdMainDB { get; set; }
    }
}
