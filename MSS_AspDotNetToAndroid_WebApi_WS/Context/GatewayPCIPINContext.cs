using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Context
{
    public partial class GatewayPCIPINContext : DbContext
    {
        static GatewayPCIPINContext()
        {
            Database.SetInitializer<GatewayPCIPINContext>(null);
        }

        public GatewayPCIPINContext()
            : base("Name=GatewayPCIPINContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<gw_bank> gw_bank { get; set; }
        public DbSet<gw_bin> gw_bin { get; set; }
        public DbSet<gw_close_day> gw_close_day { get; set; }
        public DbSet<gw_default_field> gw_default_field { get; set; }
        public DbSet<gw_default_field_header> gw_default_field_header { get; set; }
        public DbSet<gw_default_subfield> gw_default_subfield { get; set; }
        public DbSet<gw_default_template> gw_default_template { get; set; }
        public DbSet<gw_default_trnsct_type> gw_default_trnsct_type { get; set; }
        public DbSet<gw_download_data> gw_download_data { get; set; }
        public DbSet<gw_emv_data> gw_emv_data { get; set; }
        public DbSet<gw_hand_shake> gw_hand_shake { get; set; }
        public DbSet<gw_host> gw_host { get; set; }
        public DbSet<gw_host_refuse_error> gw_host_refuse_error { get; set; }
        public DbSet<gw_host_trnsct_type> gw_host_trnsct_type { get; set; }
        public DbSet<gw_magasin> gw_magasin { get; set; }
        public DbSet<gw_mandatory_field> gw_mandatory_field { get; set; }
        public DbSet<gw_mandatory_field_header> gw_mandatory_field_header { get; set; }
        public DbSet<gw_mandatory_subfield> gw_mandatory_subfield { get; set; }
        public DbSet<gw_match> gw_match { get; set; }
        public DbSet<gw_merchant> gw_merchant { get; set; }
        public DbSet<gw_plage_bin> gw_plage_bin { get; set; }
        public DbSet<gw_pos_version> gw_pos_version { get; set; }
        public DbSet<gw_response_code> gw_response_code { get; set; }
        public DbSet<gw_spdh_error> gw_spdh_error { get; set; }
        public DbSet<gw_spdh_field> gw_spdh_field { get; set; }
        public DbSet<gw_spdh_field_header> gw_spdh_field_header { get; set; }
        public DbSet<gw_spdh_subfield> gw_spdh_subfield { get; set; }
        public DbSet<gw_spdh_subfield_data> gw_spdh_subfield_data { get; set; }
        public DbSet<gw_spdh_trnsct_error> gw_spdh_trnsct_error { get; set; }
        public DbSet<gw_status_code> gw_status_code { get; set; }
        public DbSet<gw_template> gw_template { get; set; }
        public DbSet<gw_terminal_bank> gw_terminal_bank { get; set; }
        public DbSet<gw_terminal_merchant> gw_terminal_merchant { get; set; }
        public DbSet<gw_tpe> gw_tpe { get; set; }
        public DbSet<gw_trnsct> gw_trnsct { get; set; }
        public DbSet<gw_trnsct_tmk> gw_trnsct_tmk { get; set; }
        public DbSet<gw_trnsct_tms> gw_trnsct_tms { get; set; }
        public DbSet<gw_user_magasin> gw_user_magasin { get; set; }
        public DbSet<gw_user_organism> gw_user_organism { get; set; }
        public DbSet<gw_user_terminal_merchant> gw_user_terminal_merchant { get; set; }
        public DbSet<gw_version> gw_version { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<OrganismIdentity> OrganismIdentities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        /*  Those 2 Tables where added by me to manage the 'Tokens on db'*/
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UserSessionToken> UserSessionTokens { get; set; }
        /*  But most likely to delete table 'Token' and work with 'UserSessionToken'*/

        // début : added by me
        public DbSet<UserVerificationCode> UserVerificationCodes { get; set; }
        // fin : added by me

        // For Notification aded by me
        public DbSet<RejectedTransactionsCounter> RejectedTransactionsCounters { get; set; }
        // fin : added by me

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new gw_bankMap());
            modelBuilder.Configurations.Add(new gw_binMap());
            modelBuilder.Configurations.Add(new gw_close_dayMap());
            modelBuilder.Configurations.Add(new gw_default_fieldMap());
            modelBuilder.Configurations.Add(new gw_default_field_headerMap());
            modelBuilder.Configurations.Add(new gw_default_subfieldMap());
            modelBuilder.Configurations.Add(new gw_default_templateMap());
            modelBuilder.Configurations.Add(new gw_default_trnsct_typeMap());
            modelBuilder.Configurations.Add(new gw_download_dataMap());
            modelBuilder.Configurations.Add(new gw_emv_dataMap());
            modelBuilder.Configurations.Add(new gw_hand_shakeMap());
            modelBuilder.Configurations.Add(new gw_hostMap());
            modelBuilder.Configurations.Add(new gw_host_refuse_errorMap());
            modelBuilder.Configurations.Add(new gw_host_trnsct_typeMap());
            modelBuilder.Configurations.Add(new gw_magasinMap());
            modelBuilder.Configurations.Add(new gw_mandatory_fieldMap());
            modelBuilder.Configurations.Add(new gw_mandatory_field_headerMap());
            modelBuilder.Configurations.Add(new gw_mandatory_subfieldMap());
            modelBuilder.Configurations.Add(new gw_matchMap());
            modelBuilder.Configurations.Add(new gw_merchantMap());
            modelBuilder.Configurations.Add(new gw_plage_binMap());
            modelBuilder.Configurations.Add(new gw_pos_versionMap());
            modelBuilder.Configurations.Add(new gw_response_codeMap());
            modelBuilder.Configurations.Add(new gw_spdh_errorMap());
            modelBuilder.Configurations.Add(new gw_spdh_fieldMap());
            modelBuilder.Configurations.Add(new gw_spdh_field_headerMap());
            modelBuilder.Configurations.Add(new gw_spdh_subfieldMap());
            modelBuilder.Configurations.Add(new gw_spdh_subfield_dataMap());
            modelBuilder.Configurations.Add(new gw_spdh_trnsct_errorMap());
            modelBuilder.Configurations.Add(new gw_status_codeMap());
            modelBuilder.Configurations.Add(new gw_templateMap());
            modelBuilder.Configurations.Add(new gw_terminal_bankMap());
            modelBuilder.Configurations.Add(new gw_terminal_merchantMap());
            modelBuilder.Configurations.Add(new gw_tpeMap());
            modelBuilder.Configurations.Add(new gw_trnsctMap());
            modelBuilder.Configurations.Add(new gw_trnsct_tmkMap());
            modelBuilder.Configurations.Add(new gw_trnsct_tmsMap());
            modelBuilder.Configurations.Add(new gw_user_magasinMap());
            modelBuilder.Configurations.Add(new gw_user_organismMap());
            modelBuilder.Configurations.Add(new gw_user_terminal_merchantMap());
            modelBuilder.Configurations.Add(new gw_versionMap());
            modelBuilder.Configurations.Add(new InformationMap());
            modelBuilder.Configurations.Add(new OrganismIdentityMap());
            modelBuilder.Configurations.Add(new OrganizationMap());
            modelBuilder.Configurations.Add(new OrganizationTypeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            /*  Those 2 Mapings where added by me to manage the 'Tokens on db'*/
            modelBuilder.Configurations.Add(new TokenMap());
            modelBuilder.Configurations.Add(new UserSessionTokenMap());
            /*  But most likely to delete table 'TokenMap' and work with 'UserSessionTokenMap'*/
            // début : added by me
            modelBuilder.Configurations.Add(new UserVerificationCodeMap());
            // fin : added by me
            // For Notification aded by me
            modelBuilder.Configurations.Add(new RejectedTransactionsCounterMap());
            // fin : added by me

        }
    }
}
