using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_mandatory_field_header
    {
        public string gw_mandatory_field_header_template_id { get; set; }
        public string gw_mandatory_field_header_header_id { get; set; }
        public int gw_mandatory_field_header_is_mandatory { get; set; }
        public virtual gw_spdh_field_header gw_spdh_field_header { get; set; }
        public virtual gw_template gw_template { get; set; }
    }
}
