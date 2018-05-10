using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_trnsctMap : EntityTypeConfiguration<gw_trnsct>
    {
        public gw_trnsctMap()
        {
            // Primary Key
            this.HasKey(t => t.idTransaction);

            // Properties
            this.Property(t => t.idTransaction)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EtatTransaction)
                .HasMaxLength(50);

            this.Property(t => t.EtatTransaction2)
                .HasMaxLength(50);

            this.Property(t => t.EtatCloture)
                .HasMaxLength(50);

            this.Property(t => t.IdCloture)
                .HasMaxLength(50);

            this.Property(t => t.IdMerchant)
                .HasMaxLength(50);

            this.Property(t => t.IdMagasin)
                .HasMaxLength(50);

            this.Property(t => t.IdTerminalMerchant)
                .HasMaxLength(50);

            this.Property(t => t.IdTerminal)
                .HasMaxLength(50);

            this.Property(t => t.IMEI)
                .HasMaxLength(50);

            this.Property(t => t.CurrentDate)
                .HasMaxLength(6);

            this.Property(t => t.CurrentTime)
                .HasMaxLength(6);

            this.Property(t => t.CurrentDateTimeTPE)
                .HasMaxLength(50);

            this.Property(t => t.Transactiontype)
                .HasMaxLength(50);

            this.Property(t => t.TransactionSupport)
                .HasMaxLength(50);

            this.Property(t => t.ResponseCode)
                .HasMaxLength(50);

            this.Property(t => t.ResponseCodeAnnulation)
                .HasMaxLength(50);

            this.Property(t => t.InvoiceNumber)
                .HasMaxLength(10);

            this.Property(t => t.IdHost)
                .HasMaxLength(50);

            this.Property(t => t.HostRoutage)
                .HasMaxLength(50);

            this.Property(t => t.AnnulationHostRoutage)
                .HasMaxLength(50);

            this.Property(t => t.BinaryVersion)
                .HasMaxLength(50);

            this.Property(t => t.ConfVersion)
                .HasMaxLength(50);

            this.Property(t => t.BankOfRequest)
                .HasMaxLength(50);

            this.Property(t => t.MerchantType)
                .HasMaxLength(50);

            this.Property(t => t.CodeStatus)
                .HasMaxLength(50);

            this.Property(t => t.FID_F_ApprovalCode)
                .HasMaxLength(50);

            this.Property(t => t.DateSystemTransaction)
                .HasMaxLength(50);

            this.Property(t => t.TimeSystemTransaction)
                .HasMaxLength(50);

            this.Property(t => t.TransactionAutorization)
                .HasMaxLength(50);

            this.Property(t => t.Detail)
                .HasMaxLength(50);

            this.Property(t => t.CurrentDateAnnulation)
                .HasMaxLength(6);

            this.Property(t => t.CurrentTimeAnnulation)
                .HasMaxLength(6);

            this.Property(t => t.DateSystemTransactionAnnulation)
                .HasMaxLength(50);

            this.Property(t => t.TimeSystemTransactionAnnulation)
                .HasMaxLength(50);

            this.Property(t => t.AccountType)
                .HasMaxLength(2);

            this.Property(t => t.AcquirerIdentifier)
                .HasMaxLength(12);

            this.Property(t => t.AdditionalTerminalCapabilities)
                .HasMaxLength(10);

            this.Property(t => t.AmountAuthorisedBinary)
                .HasMaxLength(8);

            this.Property(t => t.AmountAuthorisedNumeric)
                .HasMaxLength(12);

            this.Property(t => t.AmountOtherBinary)
                .HasMaxLength(8);

            this.Property(t => t.AmountOtherNumeric)
                .HasMaxLength(12);

            this.Property(t => t.AmountReferenceCurrency)
                .HasMaxLength(8);

            this.Property(t => t.ApplicationCryptogram)
                .HasMaxLength(16);

            this.Property(t => t.ApplicationCurrencyCode)
                .HasMaxLength(4);

            this.Property(t => t.ApplicationCurrencyExponent)
                .HasMaxLength(2);

            this.Property(t => t.ApplicationDiscretionaryData)
                .HasMaxLength(64);

            this.Property(t => t.ApplicationEffectiveDate)
                .HasMaxLength(6);

            this.Property(t => t.ApplicationExpirationDate)
                .HasMaxLength(6);

            this.Property(t => t.ApplicationIdentifierCard)
                .HasMaxLength(32);

            this.Property(t => t.ApplicationIdentifierTerminal)
                .HasMaxLength(32);

            this.Property(t => t.ApplicationInterchangeProfile)
                .HasMaxLength(4);

            this.Property(t => t.ApplicationLabel)
                .HasMaxLength(32);

            this.Property(t => t.ApplicationPreferredName)
                .HasMaxLength(32);

            this.Property(t => t.ApplicationPrimaryAccountNumberSequenceNumber)
                .HasMaxLength(2);

            this.Property(t => t.ApplicationPriorityIndicator)
                .HasMaxLength(2);

            this.Property(t => t.ApplicationReferenceCurrency)
                .HasMaxLength(16);

            this.Property(t => t.ApplicationReferenceCurrencyExponent)
                .HasMaxLength(8);

            this.Property(t => t.ApplicationTransactionCounter)
                .HasMaxLength(4);

            this.Property(t => t.ApplicationUsageControl)
                .HasMaxLength(4);

            this.Property(t => t.CardApplicationVersionNumber)
                .HasMaxLength(4);

            this.Property(t => t.TerminalApplicationVersionNumber)
                .HasMaxLength(4);

            this.Property(t => t.AuthorisationCode)
                .HasMaxLength(12);

            this.Property(t => t.AuthorisationResponseCode)
                .HasMaxLength(4);

            this.Property(t => t.AuthorisationResponseCryptogram)
                .HasMaxLength(16);

            this.Property(t => t.BankIdentifierCode)
                .HasMaxLength(22);

            this.Property(t => t.CardStatusUpdate)
                .HasMaxLength(8);

            this.Property(t => t.CardholderName)
                .HasMaxLength(52);

            this.Property(t => t.CardholderNameExtended)
                .HasMaxLength(90);

            this.Property(t => t.CardCertificationAuthorityPublicKeyIndex)
                .HasMaxLength(2);

            this.Property(t => t.TerminalCertificationAuthorityPublicKeyIndex)
                .HasMaxLength(2);

            this.Property(t => t.CryptogramInformationData)
                .HasMaxLength(2);

            this.Property(t => t.DataAuthenticationCode)
                .HasMaxLength(4);

            this.Property(t => t.DedicatedFileName)
                .HasMaxLength(32);

            this.Property(t => t.DirectoryDefinitionFileName)
                .HasMaxLength(32);

            this.Property(t => t.ICCDynamicNumber)
                .HasMaxLength(16);

            this.Property(t => t.IntegratedCircuitCardPINEnciphermentPublicKeyExponent)
                .HasMaxLength(6);

            this.Property(t => t.IntegratedCircuitCardPublicKeyExponent)
                .HasMaxLength(6);

            this.Property(t => t.InterfaceDeviceSerialNumber)
                .HasMaxLength(16);

            this.Property(t => t.InternationalBankAccountNumber)
                .HasMaxLength(78);

            this.Property(t => t.IssuerActionCodeDefault)
                .HasMaxLength(10);

            this.Property(t => t.IssuerActionCodeDenial)
                .HasMaxLength(10);

            this.Property(t => t.IssuerActionCodeOnline)
                .HasMaxLength(10);

            this.Property(t => t.IssuerApplicationData)
                .HasMaxLength(64);

            this.Property(t => t.IssuerAuthenticationData)
                .HasMaxLength(32);

            this.Property(t => t.IssuerCodeTableIndex)
                .HasMaxLength(2);

            this.Property(t => t.IssuerCountryCode)
                .HasMaxLength(4);

            this.Property(t => t.IssuerCountryCode2)
                .HasMaxLength(4);

            this.Property(t => t.IssuerCountryCode3)
                .HasMaxLength(6);

            this.Property(t => t.IssuerIdentificationNumber)
                .HasMaxLength(6);

            this.Property(t => t.IssuerPublicKeyExponent)
                .HasMaxLength(6);

            this.Property(t => t.IssuerScriptIdentifier)
                .HasMaxLength(8);

            this.Property(t => t.LanguagePreference)
                .HasMaxLength(16);

            this.Property(t => t.LastOnlineApplicationTransactionCounterRegister)
                .HasMaxLength(4);

            this.Property(t => t.LogEntry)
                .HasMaxLength(4);

            this.Property(t => t.LowerConsecutiveOfflineLimit)
                .HasMaxLength(2);

            this.Property(t => t.MerchantCategoryCode)
                .HasMaxLength(4);

            this.Property(t => t.MerchantIdentifier)
                .HasMaxLength(30);

            this.Property(t => t.PersonalIdentificationNumberTryCounter)
                .HasMaxLength(2);

            this.Property(t => t.PointofServiceEntryMode)
                .HasMaxLength(2);

            this.Property(t => t.ServiceCode)
                .HasMaxLength(4);

            this.Property(t => t.ShortFileIdentifier)
                .HasMaxLength(2);

            this.Property(t => t.TerminalActionCodeDefault)
                .HasMaxLength(10);

            this.Property(t => t.TerminalActionCodeDenial)
                .HasMaxLength(10);

            this.Property(t => t.TerminalActionCodeOnline)
                .HasMaxLength(10);

            this.Property(t => t.TerminalCapabilities)
                .HasMaxLength(6);

            this.Property(t => t.TerminalCountryCode)
                .HasMaxLength(4);

            this.Property(t => t.TerminalFloorLimit)
                .HasMaxLength(8);

            this.Property(t => t.TerminalIdentification)
                .HasMaxLength(16);

            this.Property(t => t.TerminalRiskManagementData)
                .HasMaxLength(16);

            this.Property(t => t.TerminalType)
                .HasMaxLength(2);

            this.Property(t => t.TerminalVerificationResults)
                .HasMaxLength(10);

            this.Property(t => t.TransactionCertificateHashValue)
                .HasMaxLength(40);

            this.Property(t => t.TransactionCurrencyCode)
                .HasMaxLength(4);

            this.Property(t => t.TransactionCurrencyExponent)
                .HasMaxLength(2);

            this.Property(t => t.TransactionDate)
                .HasMaxLength(6);

            this.Property(t => t.TransactionReferenceCurrencyCode)
                .HasMaxLength(4);

            this.Property(t => t.TransactionReferenceCurrencyExponent)
                .HasMaxLength(2);

            this.Property(t => t.TransactionSequenceCounter)
                .HasMaxLength(8);

            this.Property(t => t.TransactionStatusInformation)
                .HasMaxLength(4);

            this.Property(t => t.TransactionTime)
                .HasMaxLength(6);

            this.Property(t => t.TransactionTypeEmv)
                .HasMaxLength(2);

            this.Property(t => t.UnpredictableNumber)
                .HasMaxLength(8);

            this.Property(t => t.UpperConsecutiveOfflineLimit)
                .HasMaxLength(2);

            this.Property(t => t.CardBin)
                .HasMaxLength(6);

            this.Property(t => t.CardMask)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_trnsct");
            this.Property(t => t.idTransaction).HasColumnName("idTransaction");
            this.Property(t => t.EtatTransaction).HasColumnName("EtatTransaction");
            this.Property(t => t.EtatTransaction2).HasColumnName("EtatTransaction2");
            this.Property(t => t.EtatCloture).HasColumnName("EtatCloture");
            this.Property(t => t.IdCloture).HasColumnName("IdCloture");
            this.Property(t => t.SentTransaction).HasColumnName("SentTransaction");
            this.Property(t => t.ReceivedTransaction).HasColumnName("ReceivedTransaction");
            this.Property(t => t.CancelReceivedTransaction).HasColumnName("CancelReceivedTransaction");
            this.Property(t => t.IdMerchant).HasColumnName("IdMerchant");
            this.Property(t => t.IdMagasin).HasColumnName("IdMagasin");
            this.Property(t => t.IdTerminalMerchant).HasColumnName("IdTerminalMerchant");
            this.Property(t => t.IdTerminal).HasColumnName("IdTerminal");
            this.Property(t => t.IMEI).HasColumnName("IMEI");
            this.Property(t => t.CurrentDate).HasColumnName("CurrentDate");
            this.Property(t => t.CurrentTime).HasColumnName("CurrentTime");
            this.Property(t => t.CurrentDateTimeTPE).HasColumnName("CurrentDateTimeTPE");
            this.Property(t => t.Transactiontype).HasColumnName("Transactiontype");
            this.Property(t => t.TransactionSupport).HasColumnName("TransactionSupport");
            this.Property(t => t.ResponseCode).HasColumnName("ResponseCode");
            this.Property(t => t.ResponseCodeAnnulation).HasColumnName("ResponseCodeAnnulation");
            this.Property(t => t.InvoiceNumber).HasColumnName("InvoiceNumber");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.IdHost).HasColumnName("IdHost");
            this.Property(t => t.HostRoutage).HasColumnName("HostRoutage");
            this.Property(t => t.AnnulationHostRoutage).HasColumnName("AnnulationHostRoutage");
            this.Property(t => t.BinaryVersion).HasColumnName("BinaryVersion");
            this.Property(t => t.ConfVersion).HasColumnName("ConfVersion");
            this.Property(t => t.BankOfRequest).HasColumnName("BankOfRequest");
            this.Property(t => t.MerchantType).HasColumnName("MerchantType");
            this.Property(t => t.Track2EquivalentData).HasColumnName("Track2EquivalentData");
            this.Property(t => t.ApplicationPrimaryAccountNumber).HasColumnName("ApplicationPrimaryAccountNumber");
            this.Property(t => t.CodeStatus).HasColumnName("CodeStatus");
            this.Property(t => t.FID_F_ApprovalCode).HasColumnName("FID_F_ApprovalCode");
            this.Property(t => t.DateSystemTransaction).HasColumnName("DateSystemTransaction");
            this.Property(t => t.TimeSystemTransaction).HasColumnName("TimeSystemTransaction");
            this.Property(t => t.TransactionAutorization).HasColumnName("TransactionAutorization");
            this.Property(t => t.Detail).HasColumnName("Detail");
            this.Property(t => t.CurrentDateAnnulation).HasColumnName("CurrentDateAnnulation");
            this.Property(t => t.CurrentTimeAnnulation).HasColumnName("CurrentTimeAnnulation");
            this.Property(t => t.DateSystemTransactionAnnulation).HasColumnName("DateSystemTransactionAnnulation");
            this.Property(t => t.TimeSystemTransactionAnnulation).HasColumnName("TimeSystemTransactionAnnulation");
            this.Property(t => t.AccountType).HasColumnName("AccountType");
            this.Property(t => t.AcquirerIdentifier).HasColumnName("AcquirerIdentifier");
            this.Property(t => t.AdditionalTerminalCapabilities).HasColumnName("AdditionalTerminalCapabilities");
            this.Property(t => t.AmountAuthorisedBinary).HasColumnName("AmountAuthorisedBinary");
            this.Property(t => t.AmountAuthorisedNumeric).HasColumnName("AmountAuthorisedNumeric");
            this.Property(t => t.AmountOtherBinary).HasColumnName("AmountOtherBinary");
            this.Property(t => t.AmountOtherNumeric).HasColumnName("AmountOtherNumeric");
            this.Property(t => t.AmountReferenceCurrency).HasColumnName("AmountReferenceCurrency");
            this.Property(t => t.ApplicationCryptogram).HasColumnName("ApplicationCryptogram");
            this.Property(t => t.ApplicationCurrencyCode).HasColumnName("ApplicationCurrencyCode");
            this.Property(t => t.ApplicationCurrencyExponent).HasColumnName("ApplicationCurrencyExponent");
            this.Property(t => t.ApplicationDiscretionaryData).HasColumnName("ApplicationDiscretionaryData");
            this.Property(t => t.ApplicationEffectiveDate).HasColumnName("ApplicationEffectiveDate");
            this.Property(t => t.ApplicationExpirationDate).HasColumnName("ApplicationExpirationDate");
            this.Property(t => t.ApplicationFileLocator).HasColumnName("ApplicationFileLocator");
            this.Property(t => t.ApplicationIdentifierCard).HasColumnName("ApplicationIdentifierCard");
            this.Property(t => t.ApplicationIdentifierTerminal).HasColumnName("ApplicationIdentifierTerminal");
            this.Property(t => t.ApplicationInterchangeProfile).HasColumnName("ApplicationInterchangeProfile");
            this.Property(t => t.ApplicationLabel).HasColumnName("ApplicationLabel");
            this.Property(t => t.ApplicationPreferredName).HasColumnName("ApplicationPreferredName");
            this.Property(t => t.ApplicationPrimaryAccountNumberSequenceNumber).HasColumnName("ApplicationPrimaryAccountNumberSequenceNumber");
            this.Property(t => t.ApplicationPriorityIndicator).HasColumnName("ApplicationPriorityIndicator");
            this.Property(t => t.ApplicationReferenceCurrency).HasColumnName("ApplicationReferenceCurrency");
            this.Property(t => t.ApplicationReferenceCurrencyExponent).HasColumnName("ApplicationReferenceCurrencyExponent");
            this.Property(t => t.ApplicationTemplate).HasColumnName("ApplicationTemplate");
            this.Property(t => t.ApplicationTransactionCounter).HasColumnName("ApplicationTransactionCounter");
            this.Property(t => t.ApplicationUsageControl).HasColumnName("ApplicationUsageControl");
            this.Property(t => t.CardApplicationVersionNumber).HasColumnName("CardApplicationVersionNumber");
            this.Property(t => t.TerminalApplicationVersionNumber).HasColumnName("TerminalApplicationVersionNumber");
            this.Property(t => t.AuthorisationCode).HasColumnName("AuthorisationCode");
            this.Property(t => t.AuthorisationResponseCode).HasColumnName("AuthorisationResponseCode");
            this.Property(t => t.AuthorisationResponseCryptogram).HasColumnName("AuthorisationResponseCryptogram");
            this.Property(t => t.BankIdentifierCode).HasColumnName("BankIdentifierCode");
            this.Property(t => t.CardRiskManagementDataObjectList1).HasColumnName("CardRiskManagementDataObjectList1");
            this.Property(t => t.CardRiskManagementDataObjectList2).HasColumnName("CardRiskManagementDataObjectList2");
            this.Property(t => t.CardStatusUpdate).HasColumnName("CardStatusUpdate");
            this.Property(t => t.CardholderName).HasColumnName("CardholderName");
            this.Property(t => t.CardholderNameExtended).HasColumnName("CardholderNameExtended");
            this.Property(t => t.CardholderVerificationMethodList).HasColumnName("CardholderVerificationMethodList");
            this.Property(t => t.CardholderVerificationMethodResults).HasColumnName("CardholderVerificationMethodResults");
            this.Property(t => t.CardCertificationAuthorityPublicKeyIndex).HasColumnName("CardCertificationAuthorityPublicKeyIndex");
            this.Property(t => t.TerminalCertificationAuthorityPublicKeyIndex).HasColumnName("TerminalCertificationAuthorityPublicKeyIndex");
            this.Property(t => t.CommandTemplate).HasColumnName("CommandTemplate");
            this.Property(t => t.CryptogramInformationData).HasColumnName("CryptogramInformationData");
            this.Property(t => t.DataAuthenticationCode).HasColumnName("DataAuthenticationCode");
            this.Property(t => t.DedicatedFileName).HasColumnName("DedicatedFileName");
            this.Property(t => t.DirectoryDefinitionFileName).HasColumnName("DirectoryDefinitionFileName");
            this.Property(t => t.DirectoryDiscretionaryTemplate).HasColumnName("DirectoryDiscretionaryTemplate");
            this.Property(t => t.DynamicDataAuthenticationDataObjectList).HasColumnName("DynamicDataAuthenticationDataObjectList");
            this.Property(t => t.FileControlInformationIssuerDiscretionaryData).HasColumnName("FileControlInformationIssuerDiscretionaryData");
            this.Property(t => t.FileControlInformationProprietaryTemplate).HasColumnName("FileControlInformationProprietaryTemplate");
            this.Property(t => t.FileControlInformationTemplate).HasColumnName("FileControlInformationTemplate");
            this.Property(t => t.ICCDynamicNumber).HasColumnName("ICCDynamicNumber");
            this.Property(t => t.IntegratedCircuitCardPINEnciphermentPublicKeyCertificate).HasColumnName("IntegratedCircuitCardPINEnciphermentPublicKeyCertificate");
            this.Property(t => t.IntegratedCircuitCardPINEnciphermentPublicKeyExponent).HasColumnName("IntegratedCircuitCardPINEnciphermentPublicKeyExponent");
            this.Property(t => t.IntegratedCircuitCardPINEnciphermentPublicKeyRemainder).HasColumnName("IntegratedCircuitCardPINEnciphermentPublicKeyRemainder");
            this.Property(t => t.IntegratedCircuitCardPublicKeyCertificate).HasColumnName("IntegratedCircuitCardPublicKeyCertificate");
            this.Property(t => t.IntegratedCircuitCardPublicKeyExponent).HasColumnName("IntegratedCircuitCardPublicKeyExponent");
            this.Property(t => t.IntegratedCircuitCardPublicKeyRemainder).HasColumnName("IntegratedCircuitCardPublicKeyRemainder");
            this.Property(t => t.InterfaceDeviceSerialNumber).HasColumnName("InterfaceDeviceSerialNumber");
            this.Property(t => t.InternationalBankAccountNumber).HasColumnName("InternationalBankAccountNumber");
            this.Property(t => t.IssuerActionCodeDefault).HasColumnName("IssuerActionCodeDefault");
            this.Property(t => t.IssuerActionCodeDenial).HasColumnName("IssuerActionCodeDenial");
            this.Property(t => t.IssuerActionCodeOnline).HasColumnName("IssuerActionCodeOnline");
            this.Property(t => t.IssuerApplicationData).HasColumnName("IssuerApplicationData");
            this.Property(t => t.IssuerAuthenticationData).HasColumnName("IssuerAuthenticationData");
            this.Property(t => t.IssuerCodeTableIndex).HasColumnName("IssuerCodeTableIndex");
            this.Property(t => t.IssuerCountryCode).HasColumnName("IssuerCountryCode");
            this.Property(t => t.IssuerCountryCode2).HasColumnName("IssuerCountryCode2");
            this.Property(t => t.IssuerCountryCode3).HasColumnName("IssuerCountryCode3");
            this.Property(t => t.IssuerIdentificationNumber).HasColumnName("IssuerIdentificationNumber");
            this.Property(t => t.IssuerPublicKeyCertificate).HasColumnName("IssuerPublicKeyCertificate");
            this.Property(t => t.IssuerPublicKeyExponent).HasColumnName("IssuerPublicKeyExponent");
            this.Property(t => t.IssuerPublicKeyRemainder).HasColumnName("IssuerPublicKeyRemainder");
            this.Property(t => t.IssuerScriptCommand).HasColumnName("IssuerScriptCommand");
            this.Property(t => t.IssuerScriptIdentifier).HasColumnName("IssuerScriptIdentifier");
            this.Property(t => t.IssuerScriptTemplate1).HasColumnName("IssuerScriptTemplate1");
            this.Property(t => t.IssuerScriptTemplate2).HasColumnName("IssuerScriptTemplate2");
            this.Property(t => t.IssuerURL).HasColumnName("IssuerURL");
            this.Property(t => t.LanguagePreference).HasColumnName("LanguagePreference");
            this.Property(t => t.LastOnlineApplicationTransactionCounterRegister).HasColumnName("LastOnlineApplicationTransactionCounterRegister");
            this.Property(t => t.LogEntry).HasColumnName("LogEntry");
            this.Property(t => t.LogFormat).HasColumnName("LogFormat");
            this.Property(t => t.LowerConsecutiveOfflineLimit).HasColumnName("LowerConsecutiveOfflineLimit");
            this.Property(t => t.MerchantCategoryCode).HasColumnName("MerchantCategoryCode");
            this.Property(t => t.MerchantIdentifier).HasColumnName("MerchantIdentifier");
            this.Property(t => t.MerchantNameandLocation).HasColumnName("MerchantNameandLocation");
            this.Property(t => t.PersonalIdentificationNumberTryCounter).HasColumnName("PersonalIdentificationNumberTryCounter");
            this.Property(t => t.PointofServiceEntryMode).HasColumnName("PointofServiceEntryMode");
            this.Property(t => t.ProcessingOptionsDataObjectList).HasColumnName("ProcessingOptionsDataObjectList");
            this.Property(t => t.READRECORDResponseMessageTemplate).HasColumnName("READRECORDResponseMessageTemplate");
            this.Property(t => t.ResponseMessageTemplateFormat1).HasColumnName("ResponseMessageTemplateFormat1");
            this.Property(t => t.ResponseMessageTemplateFormat2).HasColumnName("ResponseMessageTemplateFormat2");
            this.Property(t => t.ServiceCode).HasColumnName("ServiceCode");
            this.Property(t => t.ShortFileIdentifier).HasColumnName("ShortFileIdentifier");
            this.Property(t => t.SignedDynamicApplicationData).HasColumnName("SignedDynamicApplicationData");
            this.Property(t => t.SignedStaticApplicationData).HasColumnName("SignedStaticApplicationData");
            this.Property(t => t.StaticDataAuthenticationTagList).HasColumnName("StaticDataAuthenticationTagList");
            this.Property(t => t.TerminalActionCodeDefault).HasColumnName("TerminalActionCodeDefault");
            this.Property(t => t.TerminalActionCodeDenial).HasColumnName("TerminalActionCodeDenial");
            this.Property(t => t.TerminalActionCodeOnline).HasColumnName("TerminalActionCodeOnline");
            this.Property(t => t.TerminalCapabilities).HasColumnName("TerminalCapabilities");
            this.Property(t => t.TerminalCountryCode).HasColumnName("TerminalCountryCode");
            this.Property(t => t.TerminalFloorLimit).HasColumnName("TerminalFloorLimit");
            this.Property(t => t.TerminalIdentification).HasColumnName("TerminalIdentification");
            this.Property(t => t.TerminalRiskManagementData).HasColumnName("TerminalRiskManagementData");
            this.Property(t => t.TerminalType).HasColumnName("TerminalType");
            this.Property(t => t.TerminalVerificationResults).HasColumnName("TerminalVerificationResults");
            this.Property(t => t.Track1DiscretionaryData).HasColumnName("Track1DiscretionaryData");
            this.Property(t => t.Track2DiscretionaryData).HasColumnName("Track2DiscretionaryData");
            this.Property(t => t.TransactionCertificateDataObjectList).HasColumnName("TransactionCertificateDataObjectList");
            this.Property(t => t.TransactionCertificateHashValue).HasColumnName("TransactionCertificateHashValue");
            this.Property(t => t.TransactionCurrencyCode).HasColumnName("TransactionCurrencyCode");
            this.Property(t => t.TransactionCurrencyExponent).HasColumnName("TransactionCurrencyExponent");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.TransactionPersonalIdentificationNumberData).HasColumnName("TransactionPersonalIdentificationNumberData");
            this.Property(t => t.TransactionReferenceCurrencyCode).HasColumnName("TransactionReferenceCurrencyCode");
            this.Property(t => t.TransactionReferenceCurrencyExponent).HasColumnName("TransactionReferenceCurrencyExponent");
            this.Property(t => t.TransactionSequenceCounter).HasColumnName("TransactionSequenceCounter");
            this.Property(t => t.TransactionStatusInformation).HasColumnName("TransactionStatusInformation");
            this.Property(t => t.TransactionTime).HasColumnName("TransactionTime");
            this.Property(t => t.TransactionTypeEmv).HasColumnName("TransactionTypeEmv");
            this.Property(t => t.UnpredictableNumber).HasColumnName("UnpredictableNumber");
            this.Property(t => t.UpperConsecutiveOfflineLimit).HasColumnName("UpperConsecutiveOfflineLimit");
            this.Property(t => t.EncryptedPIN).HasColumnName("EncryptedPIN");
            this.Property(t => t.PEKVersionNumber).HasColumnName("PEKVersionNumber");
            this.Property(t => t.CardBin).HasColumnName("CardBin");
            this.Property(t => t.CardMask).HasColumnName("CardMask");

            // Relationships
            this.HasOptional(t => t.gw_close_day)
                .WithMany(t => t.gw_trnsct)
                .HasForeignKey(d => d.IdCloture);

        }
    }
}
