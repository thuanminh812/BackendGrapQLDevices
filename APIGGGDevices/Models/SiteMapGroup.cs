using System;
using System.Collections.Generic;

namespace APIGGGDevices.Models
{
    public partial class SiteMapGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? SiteMapId { get; set; }

        public virtual Group? Group { get; set; }
    }
}
