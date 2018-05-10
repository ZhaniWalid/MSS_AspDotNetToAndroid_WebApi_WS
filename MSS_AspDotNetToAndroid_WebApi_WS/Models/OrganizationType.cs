using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            this.AspNetRoles = new List<AspNetRole>();
            this.Organizations = new List<Organization>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
