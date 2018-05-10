using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_subfield
    {
        public gw_spdh_subfield()
        {
            this.gw_default_subfield = new List<gw_default_subfield>();
            this.gw_mandatory_subfield = new List<gw_mandatory_subfield>();
            this.gw_spdh_subfield_data = new List<gw_spdh_subfield_data>();
        }

        public string gw_spdh_subfield_id { get; set; }
        public string gw_spdh_subfield_label { get; set; }
        public string gw_spdh_subfield_sfid { get; set; }
        public string gw_spdh_subfield_format { get; set; }
        public int gw_spdh_subfield_min_length { get; set; }
        public int gw_spdh_subfield_max_length { get; set; }
        public string gw_spdh_subfield_field_fid { get; set; }
        public int gw_spdh_subfield_padding { get; set; }
        public string gw_spdh_subfield_padding_char { get; set; }
        public int gw_spdh_subfield_extend_control { get; set; }
        public virtual ICollection<gw_default_subfield> gw_default_subfield { get; set; }
        public virtual ICollection<gw_mandatory_subfield> gw_mandatory_subfield { get; set; }
        public virtual ICollection<gw_spdh_subfield_data> gw_spdh_subfield_data { get; set; }
    }
}
