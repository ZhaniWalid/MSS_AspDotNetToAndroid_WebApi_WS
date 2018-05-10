using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_field
    {
        public gw_spdh_field()
        {
            this.gw_default_field = new List<gw_default_field>();
            this.gw_mandatory_field = new List<gw_mandatory_field>();
        }

        public string gw_spdh_field_id { get; set; }
        public string gw_spdh_field_fid { get; set; }
        public string gw_spdh_field_format { get; set; }
        public int gw_spdh_field_min_lengh { get; set; }
        public int gw_spdh_field_max_length { get; set; }
        public string gw_spdh_field_label { get; set; }
        public Nullable<int> gw_spdh_field_request_response { get; set; }
        public int gw_spdh_field_padding { get; set; }
        public string gw_spdh_field_padding_char { get; set; }
        public int gw_spdh_field_extend_control { get; set; }
        public virtual ICollection<gw_default_field> gw_default_field { get; set; }
        public virtual ICollection<gw_mandatory_field> gw_mandatory_field { get; set; }
    }
}
