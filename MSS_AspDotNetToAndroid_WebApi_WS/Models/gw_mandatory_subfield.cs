using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_mandatory_subfield
    {
        public string gw_mandatory_subfield_template_id { get; set; }
        public string gw_mandatory_subfield_subfield_id { get; set; }
        public int gw_mandatory_subfield_is_mandatory { get; set; }
        public virtual gw_spdh_subfield gw_spdh_subfield { get; set; }
        public virtual gw_template gw_template { get; set; }
    }
}
