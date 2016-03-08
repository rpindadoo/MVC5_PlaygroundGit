using System;
using System.ComponentModel.DataAnnotations;
using Sample.DataAccess.Entities.Interfaces;

namespace Sample.DataAccess.Entities{
    public class User : IEntity{

        [Key]
        public Guid Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public string FullName { get { return string.Concat(Firstname, " ", Lastname); } }
    }
}