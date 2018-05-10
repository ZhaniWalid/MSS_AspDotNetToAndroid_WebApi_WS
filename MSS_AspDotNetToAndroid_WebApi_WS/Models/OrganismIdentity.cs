using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class OrganismIdentity
    {
        public OrganismIdentity()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
