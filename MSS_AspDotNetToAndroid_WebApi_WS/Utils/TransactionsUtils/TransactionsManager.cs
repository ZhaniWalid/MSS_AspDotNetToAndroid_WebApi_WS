using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.TransactionsUtils
{
    public class TransactionsManager
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);

        private TransactionsRepository _transactionsRepository;

        public TransactionsManager()
        {
            _transactionsRepository = new TransactionsRepository();
        }

        public List<gw_trnsct_GeneralBindingModel> getGeneralTransactionsData()
        {
            var returnedTransactionsList = _transactionsRepository.filteredGeneralTransactionsData();
            var returnedListBinCards = _transactionsRepository.getAllBinCardsForPayements();
            var returnedListBank = _transactionsRepository.getAllBank();

            var listGeneralTransactionsData = new List<gw_trnsct_GeneralBindingModel>();

            // General Part
            string idTranscation_ToReturn = " ", IdMerchant_ToReturn = " ", IdTerminalMerchant_ToReturn = " ";
            string IdHost_ToReturn = " ", EtatTransaction_ToReturn = " ";  //  AmountAuthorisedNumeric_ToReturn = " "
            string BankOfRequest_ToReturn = " ";
            double? Amount_ToReturn = 0; // ? => Nullable

            // Extended part
            string EtatCloture_ToReturn = " ", CurrentDate_ToReturn = " ", TimeSystemTransaction_ToReturn = " ";
            string Transactiontype_ToReturn = " ", ResponseCode_ToReturn = " ", FID_F_ApprovalCode_ToReturn = " ", CardMask_ToReturn = " ";

            // Another Fields for Ticket Part
            string ApplicationIdentifierCard_ToReturn = " ", ApplicationCryptogram_ToReturn = " ", TerminalVerificationResults_ToReturn = " ";
            string TransactionStatusInformation_ToReturn = " ",  CardBin_ToReturn= " ";
            string CardUsedForPayement_ToReturn = " ", BankIdGateWay_ToReturn = " ", BankNameGateWay_ToReturn = " ";

            if (returnedTransactionsList.Count != 0 && returnedTransactionsList != null)
            {
                
                foreach (gw_trnsct trnsc in returnedTransactionsList)
                {
             
                     // General Part
                     idTranscation_ToReturn = trnsc.idTransaction;
                     IdMerchant_ToReturn = trnsc.IdMerchant;
                     IdTerminalMerchant_ToReturn = trnsc.IdTerminalMerchant;
                     IdHost_ToReturn = trnsc.IdHost;
                     Amount_ToReturn = trnsc.Amount;
                     EtatTransaction_ToReturn = trnsc.EtatTransaction;
                     BankOfRequest_ToReturn = trnsc.BankOfRequest;

                     // Extended Part
                     EtatCloture_ToReturn = trnsc.EtatCloture;
                     CurrentDate_ToReturn = trnsc.CurrentDate;
                     TimeSystemTransaction_ToReturn = trnsc.TimeSystemTransaction;
                     Transactiontype_ToReturn = trnsc.Transactiontype;
                     ResponseCode_ToReturn = trnsc.ResponseCode;
                     FID_F_ApprovalCode_ToReturn = trnsc.FID_F_ApprovalCode;
                     CardMask_ToReturn = trnsc.CardMask;

                     // Another Fields for Ticket Part
                     ApplicationIdentifierCard_ToReturn = trnsc.ApplicationIdentifierCard; // APPID
                     ApplicationCryptogram_ToReturn = trnsc.ApplicationCryptogram; // Sign
                     TerminalVerificationResults_ToReturn = trnsc.TerminalVerificationResults; // TVR
                     TransactionStatusInformation_ToReturn = trnsc.TransactionStatusInformation; // TSI
                     CardBin_ToReturn = trnsc.CardBin; // Carte : CardBin.gw_bin_label

                    if (returnedListBinCards != null && returnedListBinCards.Count != 0)
                    {
                       CardUsedForPayement_ToReturn = 
                                  _transactionsRepository
                                  .getCardUsedForPayement(returnedListBinCards,returnedTransactionsList,CardBin_ToReturn);
                    // 
                       BankIdGateWay_ToReturn =
                                  _transactionsRepository
                                  .getBankIdGateWay(returnedListBinCards,returnedTransactionsList,CardBin_ToReturn); 
                    }

                    if (returnedListBank != null && returnedListBank.Count != 0)
                    {
                       BankNameGateWay_ToReturn =
                                  _transactionsRepository
                                  .getBankNameGateWay(returnedListBank,returnedListBinCards,BankIdGateWay_ToReturn);
                    }
                    //
                    
                     string DayOf_CurrentDate_ToReturn = " ", MonthOf_CurrentDate_ToReturn = " ", YearOf_CurrentDate_ToReturn = " ";
                     string CurrentDate_Jusitified_ToReturn = " ";

                    if (CurrentDate_ToReturn != null)
                    {
                        var currentData_ToReturn_Length = CurrentDate_ToReturn.Length;
                        Console.WriteLine("Current Date Length is : " + currentData_ToReturn_Length);
                        //currentData_ToReturn_Length = 6 and index will be from i=0 -> i=5

                        // ChaineCaractère.Substring(StartIndex,NombreDePats)
                        DayOf_CurrentDate_ToReturn = CurrentDate_ToReturn.Substring(4, 2);
                        MonthOf_CurrentDate_ToReturn = CurrentDate_ToReturn.Substring(2, 2);
                        YearOf_CurrentDate_ToReturn = CurrentDate_ToReturn.Substring(0, 2);

                        //CurrentDate_Jusitified_ToReturn = "20" + YearOf_CurrentDate_ToReturn + "/" + MonthOf_CurrentDate_ToReturn + "/" + DayOf_CurrentDate_ToReturn;
                        CurrentDate_Jusitified_ToReturn = DayOf_CurrentDate_ToReturn + "/" + MonthOf_CurrentDate_ToReturn + "/20"+YearOf_CurrentDate_ToReturn;

                    }
                    else
                    {
                        CurrentDate_Jusitified_ToReturn = null;
                    }

                    if (ApplicationIdentifierCard_ToReturn == null)
                    {
                        ApplicationIdentifierCard_ToReturn = "---";
                    }

                    if (ApplicationCryptogram_ToReturn == null)
                    {
                        ApplicationCryptogram_ToReturn = "---";
                    }
                  
                    if (TerminalVerificationResults_ToReturn == null)
                    {
                        TerminalVerificationResults_ToReturn = "---";
                    }

                    if (TransactionStatusInformation_ToReturn == null)
                    {
                        TransactionStatusInformation_ToReturn = "---";
                    }
                    
                    if (CardUsedForPayement_ToReturn == null)
                    {
                        CardUsedForPayement_ToReturn = "---";
                    }

                    //
                    if (BankIdGateWay_ToReturn == null)
                    {
                        BankIdGateWay_ToReturn = "---";
                    }

                    if (BankNameGateWay_ToReturn == null)
                    {
                        BankNameGateWay_ToReturn = "---";
                    }

                    //
                  
                    listGeneralTransactionsData.Add(new gw_trnsct_GeneralBindingModel
                    {
                        // General Part
                        idTransaction = idTranscation_ToReturn,
                        IdMerchant = IdMerchant_ToReturn,
                        IdTerminalMerchant = IdTerminalMerchant_ToReturn,
                        IdHost = IdHost_ToReturn,
                        Amount = Amount_ToReturn,
                        EtatTransaction = EtatTransaction_ToReturn,
                        BankOfRequest = BankOfRequest_ToReturn,
                        //
                        BankId_GateWay = BankIdGateWay_ToReturn,
                        BankName_GateWay = BankNameGateWay_ToReturn,
                        //

                        // Extended part
                        EtatCloture = EtatCloture_ToReturn,
                        CurrentDate = CurrentDate_Jusitified_ToReturn, //CurrentDate_Jusitified_ToReturn
                        TimeSystemTransaction = TimeSystemTransaction_ToReturn,
                        Transactiontype = Transactiontype_ToReturn,
                        ResponseCode = ResponseCode_ToReturn,
                        FID_F_ApprovalCode = FID_F_ApprovalCode_ToReturn,
                        CardMask = CardMask_ToReturn,

                        // Another Fields for Ticket Part
                        ApplicationIdentifierCard = ApplicationIdentifierCard_ToReturn, // APPID
                        ApplicationCryptogram = ApplicationCryptogram_ToReturn, // Sign
                        TerminalVerificationResults = TerminalVerificationResults_ToReturn, // TVR
                        TransactionStatusInformation = TransactionStatusInformation_ToReturn, // TSI
                        CardUsedForPayement = CardUsedForPayement_ToReturn // Carte : CardBin.gw_bin_label

                    }
                   );

                    listGeneralTransactionsData
                                               .OrderBy(trnc => trnc.Amount)
                                               .GroupBy(trnc => trnc.BankId_GateWay)
                                               .Distinct();

                }
            }
            return listGeneralTransactionsData;
        }

        public List<gw_TransactionStatusBindingModel> getOnlyTransactionsStatus()
        {
            var returnedTransactionsList = _transactionsRepository.getAllEtatTransactions();
            var listTransactionsStatus = new List<gw_TransactionStatusBindingModel>();

            //string StatusTransaction_ToReturn = "";
            //int NbreStatusTransaction_ToReturn = 0;

            if (returnedTransactionsList.Count != 0 && returnedTransactionsList != null)
            {
                foreach (gw_trnsct trnsc in returnedTransactionsList)
                {
                    //StatusTransaction_ToReturn = trnsc.EtatTransaction;

               /*
                    var NbreTrnscAutorisee = returnedTransactionsList.Count(trnc => trnc.EtatTransaction == "Transaction autorisée");
                    var NbreTrnscNonAutorisee = returnedTransactionsList.Count(trnc => trnc.EtatTransaction == "Transaction non autorisée");
                    var NbreTrnscNonAboutie = returnedTransactionsList.Count(trnc => trnc.EtatTransaction == "Transaction non aboutie");
                    var NbreTrnscAnnulee = returnedTransactionsList.Count(trnc => trnc.EtatTransaction == "Transaction annulée");

                    switch (StatusTransaction_ToReturn)
                    {
                        case "Transaction autorisée":
                            NbreStatusTransaction_ToReturn = NbreTrnscAutorisee;
                            break;
                        case "Transaction non autorisée":
                            NbreStatusTransaction_ToReturn = NbreTrnscNonAutorisee;
                            break;
                        case "Transaction non aboutie":
                            NbreStatusTransaction_ToReturn = NbreTrnscNonAboutie;
                            break;
                        case "Transaction annulée":
                            NbreStatusTransaction_ToReturn = NbreTrnscAnnulee;
                            break;
                    }
            */

                    listTransactionsStatus = (from trn in returnedTransactionsList
                                                group trn by trn.EtatTransaction into transactionStatGroup
                                                select new gw_TransactionStatusBindingModel
                                                {
                                                    EtatTransaction = transactionStatGroup.Key,
                                                    NbreTransactionsParEtatTransaction = transactionStatGroup.Count()
                                                }
                                                ).ToList();
                    /*
                    listTransactionsStatus.Add(new gw_TransactionStatusBindingModel
                    {
                        EtatTransaction = StatusTransaction_ToReturn,
                        NbreTransactionsParEtatTransaction = NbreStatusTransaction_ToReturn
                    }
                    );
                    */

                    listTransactionsStatus.GroupBy(trn => trn.EtatTransaction)
                                          .Distinct();
                }
            }

            return listTransactionsStatus;

        }


        /*

        public List<gw_trnsct_ExtendedBindingModel> getExtendedTransactionsData()
        {
            var returnedTransactionsList = _transactionsRepository.filteredExtendedTransactionsData();
            var listExtendedTransactionsData = new List<gw_trnsct_ExtendedBindingModel>();

            string idTransaction_ToReturn = " ", EtatCloture_ToReturn = " ", CurrentDate_ToReturn = " ", TimeSystemTransaction_ToReturn = " ";
            string Transactiontype_ToReturn = " ", ResponseCode_ToReturn = " ", FID_F_ApprovalCode_ToReturn = " ", CardMask_ToReturn = " ";

            if (returnedTransactionsList.Count != 0 && returnedTransactionsList != null)
            {
                foreach (gw_trnsct trnsc in returnedTransactionsList)
                {
                    idTransaction_ToReturn = trnsc.idTransaction;
                    EtatCloture_ToReturn = trnsc.EtatCloture;
                    CurrentDate_ToReturn = trnsc.CurrentDate;
                    TimeSystemTransaction_ToReturn = trnsc.TimeSystemTransaction;
                    Transactiontype_ToReturn = trnsc.Transactiontype;
                    ResponseCode_ToReturn = trnsc.ResponseCode;
                    FID_F_ApprovalCode_ToReturn = trnsc.FID_F_ApprovalCode;
                    CardMask_ToReturn = trnsc.CardMask;

                    string DayOf_CurrentDate_ToReturn = " ", MonthOf_CurrentDate_ToReturn = " ", YearOf_CurrentDate_ToReturn = " ";
                    string CurrentDate_Jusitified_ToReturn = " ";

                    if (CurrentDate_ToReturn != null)
                    {
                        var currentData_ToReturn_Length = CurrentDate_ToReturn.Length;
                        Console.WriteLine("Current Date Length is : "+currentData_ToReturn_Length);
                        //currentData_ToReturn_Length = 6 and index will be from i=0 -> i=5

                        // ChaineCaractère.Substring(StartIndex,NombreDePats)
                        DayOf_CurrentDate_ToReturn   =   CurrentDate_ToReturn.Substring(4,2);
                        MonthOf_CurrentDate_ToReturn =   CurrentDate_ToReturn.Substring(2,2);
                        YearOf_CurrentDate_ToReturn  =   CurrentDate_ToReturn.Substring(0,2); 
                                           
                        CurrentDate_Jusitified_ToReturn = YearOf_CurrentDate_ToReturn + "/" + MonthOf_CurrentDate_ToReturn + "/" + DayOf_CurrentDate_ToReturn;

                    }else
                    {
                        CurrentDate_Jusitified_ToReturn = null;
                    }

                    listExtendedTransactionsData.Add(new gw_trnsct_ExtendedBindingModel
                     {
                        idTransaction = idTransaction_ToReturn,
                        EtatCloture = EtatCloture_ToReturn,
                        CurrentDate = CurrentDate_Jusitified_ToReturn, //CurrentDate_Jusitified_ToReturn
                        TimeSystemTransaction = TimeSystemTransaction_ToReturn,
                        Transactiontype = Transactiontype_ToReturn,
                        ResponseCode = ResponseCode_ToReturn,
                        FID_F_ApprovalCode = FID_F_ApprovalCode_ToReturn,
                        CardMask = CardMask_ToReturn
                     }
                    );

                    listExtendedTransactionsData
                                                .OrderBy(trnc => trnc.ResponseCode)
                                                .GroupBy(trnc => trnc.Transactiontype)
                                                .Distinct();                   
                }
            }

            return listExtendedTransactionsData;
        }

        */
    }
}