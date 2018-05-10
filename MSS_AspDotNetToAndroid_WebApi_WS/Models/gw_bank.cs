using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_bank
    {
        public gw_bank()
        {
            this.gw_bin = new List<gw_bin>();
            this.gw_merchant = new List<gw_merchant>();
            this.gw_plage_bin = new List<gw_plage_bin>();
            this.gw_terminal_bank = new List<gw_terminal_bank>();
        }

        public string gw_bank_id { get; set; }
        public string gw_bank_host_id { get; set; }
        public string gw_bank_name { get; set; }
        public string gw_bank_status { get; set; }
        public string gw_bank_abrev { get; set; }
        public string gw_bank_adress { get; set; }
        public string gw_bank_mail { get; set; }
        public string gw_bank_phone { get; set; }
        public virtual gw_host gw_host { get; set; }
        public virtual ICollection<gw_bin> gw_bin { get; set; }
        public virtual ICollection<gw_merchant> gw_merchant { get; set; }
        public virtual ICollection<gw_plage_bin> gw_plage_bin { get; set; }
        public virtual ICollection<gw_terminal_bank> gw_terminal_bank { get; set; }
    }
}
