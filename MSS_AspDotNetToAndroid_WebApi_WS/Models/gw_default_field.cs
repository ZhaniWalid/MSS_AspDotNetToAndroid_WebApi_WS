using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_default_field
    {
        public string gw_default_field_default_template_id { get; set; }
        public string gw_default_field_field_id { get; set; }
        public string gw_default_field_default_value { get; set; }
        public Nullable<int> gw_default_field_extend_creation { get; set; }
        public virtual gw_spdh_field gw_spdh_field { get; set; }
        public virtual gw_default_template gw_default_template { get; set; }
    }
}
