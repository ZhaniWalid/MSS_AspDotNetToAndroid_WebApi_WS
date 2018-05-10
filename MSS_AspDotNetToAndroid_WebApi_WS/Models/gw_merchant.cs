using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_merchant
    {
        public gw_merchant()
        {
            this.gw_terminal_merchant = new List<gw_terminal_merchant>();
            this.gw_tpe = new List<gw_tpe>();
        }

        public string gw_merchant_id { get; set; }
        public string gw_merchant_name { get; set; }
        public string gw_merchant_bank_id { get; set; }
        public string gw_merchant_status { get; set; }
        public string gw_merchant_abrev { get; set; }
        public string gw_merchant_adress { get; set; }
        public string gw_merchant_mail { get; set; }
        public string gw_merchant_phone { get; set; }
        public string gw_merchant_convention { get; set; }
        public Nullable<int> gw_merchant_close_day_hour { get; set; }
        public int gw_merchant_mobility { get; set; }
        public string gw_merchant_ftp_adress { get; set; }
        public Nullable<int> gw_merchant_ftp_port { get; set; }
        public string gw_merchant_ftp_user_id { get; set; }
        public string gw_merchant_ftp_password { get; set; }
        public string gw_merchant_ftp_repertoire { get; set; }
        public virtual gw_bank gw_bank { get; set; }
        public virtual ICollection<gw_terminal_merchant> gw_terminal_merchant { get; set; }
        public virtual ICollection<gw_tpe> gw_tpe { get; set; }
    }
}
