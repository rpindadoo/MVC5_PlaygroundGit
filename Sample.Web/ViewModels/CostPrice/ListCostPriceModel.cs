using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.ViewModels.CostPrice{
    
    public class ListUserCostPriceModel{
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public string UnitName { get; set; }
        public string ManagerName { get; set; }

        public string CurrentCostPriceRate { get; set; }

        public IEnumerable<ListCostPriceModel> CostPrices { get; set; }
    }

    
    public class ListCostPriceModel{
        public int Id { get; set; }
        public string PeriodStart { get; set; }
        public string PeriodEnd { get; set; }
        public string Rate { get; set; }
    }

    public class CreateCostPriceModel{
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PeriodEnd { get; set; }

        public decimal Rate { get; set; }
    }

    public class EditCostPriceModel{
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }

        public decimal Rate { get; set; }
    }
}