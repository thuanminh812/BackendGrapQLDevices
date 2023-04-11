using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class Group
    {
        public Group()
        {
            ContentGroups = new HashSet<ContentGroup>();
            PlaylistTimes = new HashSet<PlaylistTime>();
            SiteMapGroups = new HashSet<SiteMapGroup>();
            TotalScenarios = new HashSet<TotalScenario>();
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<ContentGroup> ContentGroups { get; set; }
        public virtual ICollection<PlaylistTime> PlaylistTimes { get; set; }
        public virtual ICollection<SiteMapGroup> SiteMapGroups { get; set; }
        public virtual ICollection<TotalScenario> TotalScenarios { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
