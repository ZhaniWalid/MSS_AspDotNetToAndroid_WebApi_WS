using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_host
    {
        public gw_host()
        {
            this.gw_bank = new List<gw_bank>();
            this.gw_host_refuse_error = new List<gw_host_refuse_error>();
            this.gw_host_trnsct_type = new List<gw_host_trnsct_type>();
        }

        public string gw_host_id { get; set; }
        public string gw_host_label { get; set; }
        public string gw_host_status { get; set; }
        public string gw_host_protocol { get; set; }
        public string gw_host_adress { get; set; }
        public string gw_host_port { get; set; }
        public Nullable<int> gw_host_ssl { get; set; }
        public string gw_host_second_adress { get; set; }
        public string gw_host_second_port { get; set; }
        public string gw_host_certificate { get; set; }
        public string gw_host_second_certificate { get; set; }
        public Nullable<int> gw_host_time_out_behavoir { get; set; }
        public virtual ICollection<gw_bank> gw_bank { get; set; }
        public virtual ICollection<gw_host_refuse_error> gw_host_refuse_error { get; set; }
        public virtual ICollection<gw_host_trnsct_type> gw_host_trnsct_type { get; set; }
    }
}
