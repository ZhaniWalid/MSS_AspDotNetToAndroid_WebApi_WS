using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public class RejectedTransactionsCounter
    {
        [Key]
        public int idCounterRejTrns { get; set; }
        public int lastCountedValue { get; set; }
        public int lastDifference { get; set; }
        public DateTime lastDateTimeOfCount { get; set; }
    }
}