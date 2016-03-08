using System;
using System.Linq;
using NUnit.Framework;
using Sample.DataAccess.Entities;
using Sample.DataAccess.Repository.InMemory;
using Sample.DataAccess.Specification;

namespace Sample.DataAccess.Tests.Specification{
    [TestFixture]
    public class SpecTests{
        private GenericRepository<Movie> _movieRepo;

        [SetUp]
        public void SetUp(){
            _movieRepo = new GenericRepository<Movie>();
            _movieRepo.Add(new Movie(){Date = DateTime.Today, Title = "MovieTitle"});
            _movieRepo.Add(new Movie(){Date = DateTime.Today.AddDays(-10), Title = "MovieTitle2"});
            _movieRepo.Add(new Movie(){Date = DateTime.Today.AddDays(-100), Title = "MovieTitle3"});
        }

        [Test]
        public void can_find_by_spec(){
            var movie_by_title = new Spec<Movie>(p => p.Title == "MovieTitle");

            var result = _movieRepo.Find(movie_by_title);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void can_find_by_expression(){
            var movies_older_than_20_days = _movieRepo.Find(p => p.Date > DateTime.Today.AddDays(-20));
            Assert.AreEqual(2, movies_older_than_20_days.Count());
        }

        [Test]
        public void can_find_by_composite_and_spec(){
            var movie_by_title = new Spec<Movie>(p => p.Title == "MovieTitle");
            var movies_older_than_20_days = new Spec<Movie>(p => p.Date > DateTime.Today.AddDays(-20));

            var result = _movieRepo.Find(movie_by_title.And(movies_older_than_20_days));
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void can_find_by_composite_and_spec_with_expression(){
            var movies_older_than_20_days = new Spec<Movie>(p => p.Date > DateTime.Today.AddDays(-20));

            var result = _movieRepo.Find(movies_older_than_20_days.And(p => p.Date < DateTime.Today.AddDays(-1)));
            Assert.AreEqual(1, result.Count());
        }
    }
}