using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class AudioGroup
    {
        public AudioGroup()
        {
            TotalScenarios = new HashSet<TotalScenario>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Creator { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? FileNumber { get; set; }
        public string? DataNumber { get; set; }
        public string? AudioPlaylist { get; set; }
        public string? TimeNumber { get; set; }
        public string? UserId { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<TotalScenario> TotalScenarios { get; set; }
    }
}
