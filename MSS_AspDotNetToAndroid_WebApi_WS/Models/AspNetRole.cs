using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUserRoles = new List<AspNetUserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public Nullable<int> OrganismType_Id { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
