using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class Organization
    {
        public Organization()
        {
            this.AspNetUsers = new List<AspNetUser>();
            this.Information = new List<Information>();
            this.Information1 = new List<Information>();
            this.Information2 = new List<Information>();
            this.Information3 = new List<Information>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public Nullable<int> OrganismType_Id { get; set; }
        public Nullable<int> Locked { get; set; }
        public string NumericCode { get; set; }
        public string AlphaCode { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }
        public virtual ICollection<Information> Information { get; set; }
        public virtual ICollection<Information> Information1 { get; set; }
        public virtual ICollection<Information> Information2 { get; set; }
        public virtual ICollection<Information> Information3 { get; set; }
    }
}
