using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class TotalScenario
    {
        public TotalScenario()
        {
            Devices = new HashSet<Device>();
            PlaylistTimes = new HashSet<PlaylistTime>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string? Name { get; set; }
        public string? Creator { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? TypeLcd { get; set; }
        public string? Media { get; set; }
        public string? UserId { get; set; }
        public string? DataNumber { get; set; }
        public int? FileNumber { get; set; }
        public int? AudioGroupId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual AudioGroup? AudioGroup { get; set; }
        public virtual Group? Group { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

        public virtual ICollection<PlaylistTime> PlaylistTimes { get; set; }
    }
}
