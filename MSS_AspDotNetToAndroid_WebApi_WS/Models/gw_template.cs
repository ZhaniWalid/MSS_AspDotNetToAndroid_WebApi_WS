using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_template
    {
        public gw_template()
        {
            this.gw_host_trnsct_type = new List<gw_host_trnsct_type>();
            this.gw_mandatory_field = new List<gw_mandatory_field>();
            this.gw_mandatory_field_header = new List<gw_mandatory_field_header>();
            this.gw_mandatory_subfield = new List<gw_mandatory_subfield>();
        }

        public string gw_template_id { get; set; }
        public string gw_template_description { get; set; }
        public virtual ICollection<gw_host_trnsct_type> gw_host_trnsct_type { get; set; }
        public virtual ICollection<gw_mandatory_field> gw_mandatory_field { get; set; }
        public virtual ICollection<gw_mandatory_field_header> gw_mandatory_field_header { get; set; }
        public virtual ICollection<gw_mandatory_subfield> gw_mandatory_subfield { get; set; }
    }
}
