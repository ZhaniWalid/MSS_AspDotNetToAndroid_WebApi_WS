using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_terminal_merchant
    {
        public gw_terminal_merchant()
        {
            this.gw_pos_version = new List<gw_pos_version>();
            this.gw_trnsct_tms = new List<gw_trnsct_tms>();
        }

        public string gw_terminal_merchant_id { get; set; }
        public string gw_terminal_merchant_merchant_id { get; set; }
        public string gw_terminal_merchant_magasin_id { get; set; }
        public string gw_terminal_merchant_sequence_number { get; set; }
        public string gw_terminal_merchant_batch_number { get; set; }
        public string gw_terminal_merchant_imei { get; set; }
        public string gw_terminal_merchant_status { get; set; }
        public Nullable<int> gw_terminal_merchant_status_occupancy { get; set; }
        public string gw_terminal_merchant_date_status { get; set; }
        public string gw_terminal_merchant_binary_version { get; set; }
        public string gw_terminal_merchant_conf_version { get; set; }
        public virtual gw_magasin gw_magasin { get; set; }
        public virtual gw_merchant gw_merchant { get; set; }
        public virtual ICollection<gw_pos_version> gw_pos_version { get; set; }
        public virtual ICollection<gw_trnsct_tms> gw_trnsct_tms { get; set; }
    }
}
