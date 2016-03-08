using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sample.DataAccess.Entities.Interfaces;

namespace Sample.DataAccess.Entities{
    public class MovieRate : IEntity{

        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public decimal Rate { get; set; }

        [ForeignKey("User")]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }
        
        [ForeignKey("Movie")]
        public virtual Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }

}