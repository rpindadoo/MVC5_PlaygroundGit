using System;
using System.Collections.ObjectModel;

namespace Sample.Web.ViewModels.Movie{
    public class ListMovieModel{
        public Guid Id { get;  set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Collection<DataAccess.Entities.MovieRate> MovieRates { get; set; }
    }
}