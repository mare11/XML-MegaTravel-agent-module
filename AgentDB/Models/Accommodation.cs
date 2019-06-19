using AgentDB;
using AgentDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgentApp.Models
{
    [Serializable]
    public class Accommodation
    {

        /// <remarks/>
        public AccommodationType AccommodationType { get; set; }

        /// <remarks/>
        public int Category { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalService")]
        public AdditionalService[] AdditionalService { get; set; }

        /// <remarks/>
        public bool FreeCancellation { get; set; }

        /// <remarks/>
        public int CancellationDays { get; set; }

        /// <remarks/>
        public decimal CancellationPrice { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        [NotMapped]
        [System.Xml.Serialization.XmlElementAttribute("images")]
        public string[] Images { get; set; }

        /// <remarks/>
        public int NumberOfPersons { get; set; }

        public Agent Agent { get; set; }

        /// <remarks/>
        public decimal DefaultPrice { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PeriodPrice")]
        public PeriodPrice[] PeriodPrice { get; set; }

        /// <remarks/>
        public Location Location { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Unavailability")]
        public Unavailability[] Unavailability { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("Reservation", Namespace = "https://github.com/mare11/XML_MegaTravel/reservation")]
        //public Reservation[] Reservation { get; set; }

        public List<ReservationLong> ReservationIds { get; set; }

        /// <remarks/>
        public long Id { get; set; }

        public long IdMainDB { get; set; }

    }
}
