using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.ViewModels.CashTransaction{
    public class CreateCashTransactionModel{
        [DisplayName("User")]
        public string UserFullName { get; set; }

        [DisplayName("Cost price")]
        [Required]
        public string CostPrice { get; set; }

        [DisplayName("Project")]
        public string ProjectName { get; set; }

        [DisplayName("Time")]
        public TimeSpan HourSheetEntryTotalMinutes { get; set; }

        public string Debit { get; set; }

        public string Credit { get; set; }
    }
}