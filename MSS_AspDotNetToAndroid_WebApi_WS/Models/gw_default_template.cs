using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_default_template
    {
        public gw_default_template()
        {
            this.gw_default_field = new List<gw_default_field>();
            this.gw_default_field_header = new List<gw_default_field_header>();
            this.gw_default_subfield = new List<gw_default_subfield>();
            this.gw_default_trnsct_type = new List<gw_default_trnsct_type>();
        }

        public string gw_default_template_id { get; set; }
        public string gw_default_template_description { get; set; }
        public virtual ICollection<gw_default_field> gw_default_field { get; set; }
        public virtual ICollection<gw_default_field_header> gw_default_field_header { get; set; }
        public virtual ICollection<gw_default_subfield> gw_default_subfield { get; set; }
        public virtual ICollection<gw_default_trnsct_type> gw_default_trnsct_type { get; set; }
    }
}
