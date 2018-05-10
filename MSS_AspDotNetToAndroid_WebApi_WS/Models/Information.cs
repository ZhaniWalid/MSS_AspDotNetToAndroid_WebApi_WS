using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class Information
    {
        public Information()
        {
            this.Organizations = new List<Organization>();
            this.Organizations1 = new List<Organization>();
            this.Organizations2 = new List<Organization>();
            this.Organizations3 = new List<Organization>();
        }

        public int InformationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Organization> Organizations1 { get; set; }
        public virtual ICollection<Organization> Organizations2 { get; set; }
        public virtual ICollection<Organization> Organizations3 { get; set; }
    }
}
