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
        public List<AdditionalService> AdditionalServices { get; set; }
        /// <remarks/>
        public AccommodationType AccommodationType { get; set; }
        /// <remarks/>
        public int Category { get; set; }
        /// <remarks/>
        public bool FreeCancellation { get; set; }
        /// <remarks/>
        public int CancellationDays { get; set; }
        /// <remarks/>
        [Column(TypeName = "decimal(18,2)")]
        public decimal CancellationPrice { get; set; }
        /// <remarks/>
        public string Description { get; set; }
        /// <remarks/>
        [NotMapped]
        [System.Xml.Serialization.XmlElementAttribute("images")]
        public string[] Images { get; set; }
        /// <remarks/>
        public int NumberOfPersons { get; set; }

        public long agentId { get; set; }
        /// <remarks/>
        [Column(TypeName = "decimal(18,2)")]
        public decimal DefaultPrice { get; set; }

        public List<PeriodPrice> PeriodPrices { get; set; }
        /// <remarks/>
        public Location Location { get; set; }

        public List<Unavailability> Unavailabilities { get; set; }

        public List<Reservation> Reservations { get; set; }

        /// <remarks/>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

    }
}
