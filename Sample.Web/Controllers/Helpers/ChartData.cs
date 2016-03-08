using System.Collections.Generic;

namespace Sample.Web.Controllers.Helpers{
    public class ChartData
    {
        public ChartData()
        {
            PropNames = new List<string>();
            Values = new List<int>();
        }

        public List<int> Values { get; set; }
        public List<string> PropNames { get; set; }
    }
}