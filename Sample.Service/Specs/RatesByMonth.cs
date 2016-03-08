using Sample.DataAccess.Entities;
using Sample.DataAccess.Specification;

namespace Sample.Service.Specs{
    public class RatesByMonth : Spec<MovieRate>{
        public RatesByMonth(int month)
            : base(m => m.Date.Month == month) {}
    }
}