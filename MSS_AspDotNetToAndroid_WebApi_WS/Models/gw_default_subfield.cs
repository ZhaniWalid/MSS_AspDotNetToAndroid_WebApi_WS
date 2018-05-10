using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_default_subfield
    {
        public string gw_default_subfield_default_template_id { get; set; }
        public string gw_default_subfield_subfield_id { get; set; }
        public string gw_default_subfield_default_value { get; set; }
        public Nullable<int> gw_default_subfield_extend_creation { get; set; }
        public virtual gw_spdh_subfield gw_spdh_subfield { get; set; }
        public virtual gw_default_template gw_default_template { get; set; }
    }
}
