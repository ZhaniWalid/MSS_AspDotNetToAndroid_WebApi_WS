using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_terminal_bank
    {
        public string gw_terminal_bank_id { get; set; }
        public string gw_terminal_bank_bank_id { get; set; }
        public string gw_terminal_bank_sequence_number { get; set; }
        public string gw_terminal_bank_batch_number { get; set; }
        public string gw_terminal_bank_status { get; set; }
        public string gw_terminal_bank_date_status { get; set; }
        public Nullable<int> gw_terminal_bank_status_occupancy { get; set; }
        public string gw_terminal_bank_trnsct_id { get; set; }
        public virtual gw_bank gw_bank { get; set; }
    }
}
