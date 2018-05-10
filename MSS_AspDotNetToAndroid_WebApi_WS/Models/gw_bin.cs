using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_bin
    {
        public string gw_bin_id { get; set; }
        public string gw_bin_bank_id { get; set; }
        public string gw_bin_type { get; set; }
        public string gw_bin_label { get; set; }
        public string gw_bin_status { get; set; }
        public string gw_bin_bank_of_request { get; set; }
        public virtual gw_bank gw_bank { get; set; }
    }
}
