using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class Token
    {
        public int id_token { get; set; }
        public string fk_id_user { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string error { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
