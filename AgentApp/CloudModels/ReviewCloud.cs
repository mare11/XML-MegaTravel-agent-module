using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApp.CloudModels
{
    public class ReviewCloud
    {
        public long Id { get; set; }
        public long AccommodationId { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool Published { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
