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
            var listGeneralTransactionsData = new List<gw_trnsct_GeneralBindingModel>();

            string idTranscation_ToReturn = " ", IdMerchant_ToReturn = " ", IdTerminalMerchant_ToReturn = " ";
            string IdHost_ToReturn = " ", AmountAuthorisedNumeric_ToReturn = " ", EtatTransaction_ToReturn = " ";
            string BankOfRequest_ToReturn = " ";


            if (returnedTransactionsList.Count != 0 && returnedTransactionsList != null)
            {              
                foreach (gw_trnsct trnsc in returnedTransactionsList)
                {
                     idTranscation_ToReturn = trnsc.idTransaction;
                     IdMerchant_ToReturn = trnsc.IdMerchant;
                     IdTerminalMerchant_ToReturn = trnsc.IdTerminalMerchant;
                     IdHost_ToReturn = trnsc.IdHost;
                     AmountAuthorisedNumeric_ToReturn = trnsc.AmountAuthorisedNumeric;
                     EtatTransaction_ToReturn = trnsc.EtatTransaction;
                     BankOfRequest_ToReturn = trnsc.BankOfRequest;
              
                    listGeneralTransactionsData.Add(new gw_trnsct_GeneralBindingModel
                    {
                        idTransaction = idTranscation_ToReturn,
                        IdMerchant = IdMerchant_ToReturn,
                        IdTerminalMerchant = IdTerminalMerchant_ToReturn,
                        IdHost = IdHost_ToReturn,
                        AmountAuthorisedNumeric = AmountAuthorisedNumeric_ToReturn,
                        EtatTransaction = EtatTransaction_ToReturn,
                        BankOfRequest = BankOfRequest_ToReturn
                    }
                   );

                    listGeneralTransactionsData
                                               .OrderBy(trnc => trnc.AmountAuthorisedNumeric)
                                               .GroupBy(trnc => trnc.EtatTransaction)
                                               .Distinct();

                }
            }
            return listGeneralTransactionsData;
        }

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
    }
}