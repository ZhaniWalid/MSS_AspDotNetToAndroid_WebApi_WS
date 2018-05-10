using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_magasin
    {
        public gw_magasin()
        {
            this.gw_terminal_merchant = new List<gw_terminal_merchant>();
            this.gw_tpe = new List<gw_tpe>();
        }

        public string gw_magasin_id { get; set; }
        public string gw_magasin_merchant_id { get; set; }
        public string gw_magasin_label { get; set; }
        public string gw_magasin_status { get; set; }
        public Nullable<int> gw_magasin_close_day_hour { get; set; }
        public virtual ICollection<gw_terminal_merchant> gw_terminal_merchant { get; set; }
        public virtual ICollection<gw_tpe> gw_tpe { get; set; }
    }
}
