using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_plage_bin
    {
        public int gw_plage_bin_id { get; set; }
        public Nullable<int> gw_plage_bin_min { get; set; }
        public Nullable<int> gw_plage_bin_max { get; set; }
        public string gw_plage_bin_bank_id { get; set; }
        public string gw_plage_bin_description { get; set; }
        public string gw_plage_bin_status { get; set; }
        public virtual gw_bank gw_bank { get; set; }
    }
}
