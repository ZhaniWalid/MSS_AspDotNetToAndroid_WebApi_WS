using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_field_header
    {
        public gw_spdh_field_header()
        {
            this.gw_default_field_header = new List<gw_default_field_header>();
            this.gw_mandatory_field_header = new List<gw_mandatory_field_header>();
        }

        public string gw_spdh_field_header_id { get; set; }
        public int gw_spdh_field_header_position { get; set; }
        public int gw_spdh_field_header_length { get; set; }
        public string gw_spdh_field_header_format { get; set; }
        public int gw_spdh_field_header_padding { get; set; }
        public string gw_spdh_field_header_padding_char { get; set; }
        public int gw_spdh_field_header_extend_control { get; set; }
        public string gw_spdh_field_header_default_value { get; set; }
        public virtual ICollection<gw_default_field_header> gw_default_field_header { get; set; }
        public virtual ICollection<gw_mandatory_field_header> gw_mandatory_field_header { get; set; }
    }
}
