using System;

namespace Sample.Web.ViewModels.MovieRate
{
    public class CreateMovieRateModel
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Comments { get; set; }
        public decimal Rate { get; set; }
    }
}