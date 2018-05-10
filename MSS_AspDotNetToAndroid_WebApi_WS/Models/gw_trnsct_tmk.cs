using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_trnsct_tmk
    {
        public string gw_trnsct_tmk_id { get; set; }
        public string gw_id_merchant { get; set; }
        public string gw_id_magasin { get; set; }
        public string gw_trnsct_tmk_id_terminal { get; set; }
        public string gw_trnsct_tmk_serial_number { get; set; }
        public string gw_trnsct_tmk_current_date { get; set; }
        public string gw_trnsct_tmk_current_time { get; set; }
        public string gw_trnsct_tmk_TPE_trnsct_TMK_Id { get; set; }
        public string gw_trnsct_tmk_id_tmk_trnsct { get; set; }
        public Nullable<int> gw_trnsct_tmk_result_code { get; set; }
        public string gw_trnsct_tmk_status { get; set; }
        public Nullable<int> gw_trnsct_tmk_confirmation_result_code { get; set; }
    }
}
