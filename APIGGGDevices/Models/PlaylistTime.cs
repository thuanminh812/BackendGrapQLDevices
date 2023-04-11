using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class PlaylistTime
    {
        public PlaylistTime()
        {
            ContentGroups = new HashSet<ContentGroup>();
            TotalScenarios = new HashSet<TotalScenario>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string? Name { get; set; }
        public string? StartPlaylist { get; set; }
        public string? EndPlaylist { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Creator { get; set; }
        public int? TypeLcd { get; set; }
        public int? FileNumber { get; set; }
        public string? DataNumber { get; set; }
        public string? UserId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Group? Group { get; set; }

        public virtual ICollection<ContentGroup> ContentGroups { get; set; }
        public virtual ICollection<TotalScenario> TotalScenarios { get; set; }
    }
}
