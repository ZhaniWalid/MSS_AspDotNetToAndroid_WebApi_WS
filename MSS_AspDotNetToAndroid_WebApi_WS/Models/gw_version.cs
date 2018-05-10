using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_version
    {
        public gw_version()
        {
            this.gw_pos_version = new List<gw_pos_version>();
        }

        public string gw_version_id { get; set; }
        public string gw_version_zip_file { get; set; }
        public int gw_version_type { get; set; }
        public string gw_version_description { get; set; }
        public string gw_version_date_creation { get; set; }
        public Nullable<int> gw_versin_status { get; set; }
        public virtual ICollection<gw_pos_version> gw_pos_version { get; set; }
    }
}
