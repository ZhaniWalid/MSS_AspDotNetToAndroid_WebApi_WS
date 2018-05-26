using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class UserVerificationCodeMap : EntityTypeConfiguration<UserVerificationCode>
    {
        public UserVerificationCodeMap()
        {
            // Primary Key
            HasKey(t => t.IdVerifCode);

            // Properties
            Property(t => t.AspNetUser_fk_Id)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("UserVerificationCodes");
            Property(t => t.IdVerifCode).HasColumnName("IdVerifCode");
            Property(t => t.AspNetUser_fk_Id).HasColumnName("AspNetUser_fk_Id");
            Property(t => t.VerificationCode).HasColumnName("VerificationCode");
            Property(t => t.DateTimeOfVerifCode).HasColumnName("DateTimeOfVerifCode");

            // Relationships
            HasRequired(t => t.OwnerCodeAspNetUser)
                .WithMany(t => t.userVerificationsCodes)
                .HasForeignKey(t => t.AspNetUser_fk_Id);


        }
    }
}