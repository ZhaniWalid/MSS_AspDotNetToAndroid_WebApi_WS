using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_pos_version
    {
        public string gw_pos_version_id { get; set; }
        public string gw_pos_version_version_id { get; set; }
        public string gw_pos_version_terminal_merchant_id { get; set; }
        public string gw_pos_version_date_debut { get; set; }
        public string gw_pos_version_date_fin { get; set; }
        public virtual gw_terminal_merchant gw_terminal_merchant { get; set; }
        public virtual gw_version gw_version { get; set; }
    }
}
