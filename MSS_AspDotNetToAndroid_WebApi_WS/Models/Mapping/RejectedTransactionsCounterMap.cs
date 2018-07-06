using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class RejectedTransactionsCounterMap : EntityTypeConfiguration<RejectedTransactionsCounter>
    {

        public RejectedTransactionsCounterMap()
        {
            // Primary Key
            HasKey(t => t.idCounterRejTrns);

            // Properties

            // Table & Column Mappings
            ToTable("RejectedTransactionsCounter");
            Property(t => t.idCounterRejTrns).HasColumnName("idCounterRejTrns");
            Property(t => t.lastCountedValue).HasColumnName("lastCountedValue");
            Property(t => t.lastDateTimeOfCount).HasColumnName("lastDateTimeOfCount");
            Property(t => t.lastDifference).HasColumnName("lastDifference");

            // Relationships

        }

    }
}