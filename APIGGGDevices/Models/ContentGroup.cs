using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class ContentGroup
    {
        public ContentGroup()
        {
            PlaylistTimes = new HashSet<PlaylistTime>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string? Name { get; set; }
        public int? FileNumber { get; set; }
        public string? DataNumber { get; set; }
        public string? Creator { get; set; }
        public string? Playlists { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? TypeLcd { get; set; }
        public string? UserId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Group? Group { get; set; }

        public virtual ICollection<PlaylistTime> PlaylistTimes { get; set; }
    }
}
