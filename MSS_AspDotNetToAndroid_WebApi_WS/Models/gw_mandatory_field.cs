using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_mandatory_field
    {
        public string gw_mandatory_field_template_id { get; set; }
        public string gw_mandatory_field_field_id { get; set; }
        public int gw_mandatory_field_is_mandatory { get; set; }
        public virtual gw_spdh_field gw_spdh_field { get; set; }
        public virtual gw_template gw_template { get; set; }
    }
}
