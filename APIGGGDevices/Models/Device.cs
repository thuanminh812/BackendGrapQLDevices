using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class Device
    {
        public Device()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string? Name { get; set; }
        public string? Imei { get; set; }
        public bool? Status { get; set; }
        public int? TotalScenarioId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TotalScenario? TotalScenario { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
