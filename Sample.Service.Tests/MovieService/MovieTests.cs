using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Sample.DataAccess.Entities;
using Sample.Service.Core;

namespace Sample.Service.Tests.MovieService{
    [TestFixture]
    public class SpecTests{
        private Mock<IService<Movie>> _movieService;

        [SetUp]
        public void SetUp(){
            _movieService = new Mock<IService<Movie>>();
            _movieService.Setup(x => x.GetAll()).Returns(new List<Movie>{
                new Movie(){Date = DateTime.Today, Title = "MovieTitle"},
                new Movie(){Date = DateTime.Today.AddDays(-10), Title = "MovieTitle2"},
                new Movie(){Date = DateTime.Today.AddDays(-100), Title = "MovieTitle3"}
            }.AsQueryable());
        }

        [Test]
        public void get_all_returns_all(){
            var result = _movieService.Object.GetAll();
            Assert.AreEqual(3, result.Count());
        }
    }
}