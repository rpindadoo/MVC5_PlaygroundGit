using System;

namespace Sample.Web.ViewModels.MovieRate{
    public class ListMovieRateModel{
        public Guid Id { get;  set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int Rate { get; set; }

        public string Title { get; set; }
        public string User { get; set; }
    }
}