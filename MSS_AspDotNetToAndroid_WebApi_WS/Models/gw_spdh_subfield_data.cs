using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_subfield_data
    {
        public string gw_spdh_subfield_data_emv_tag { get; set; }
        public string gw_spdh_subfield_data_subfield_id { get; set; }
        public string gw_spdh_subfield_data_emv_version { get; set; }
        public int gw_spdh_subfield_data_position { get; set; }
        public int gw_spdh_subfield_data_min_length { get; set; }
        public int gw_spdh_subfield_data_max_length { get; set; }
        public string gw_spdh_subfield_data_format { get; set; }
        public int gw_spdh_subfield_data_request_response { get; set; }
        public Nullable<int> gw_spdh_subfield_data_extend_control { get; set; }
        public virtual gw_spdh_subfield gw_spdh_subfield { get; set; }
    }
}
