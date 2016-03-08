using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Sample.DataAccess.Entities.Interfaces;

namespace Sample.DataAccess.Entities{
    public class Movie : IEntity{
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public DateTime Date { get; set; }

        public virtual Collection<MovieRate> MovieRates { get; set; }
    }
}