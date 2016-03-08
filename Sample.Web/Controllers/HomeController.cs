using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Sample.DataAccess.Entities;
using Sample.Service.Core;
using Sample.Service.EntityServices;
using Sample.Service.Specs;
using Sample.Web.Controllers.Helpers;
using Sample.Web.ViewModels.Movie;
using Sample.Web.ViewModels.MovieRate;

namespace Sample.Web.Controllers{
    public class HomeController : Controller{
        private readonly IService<Movie> _movieService;
        private readonly IChartHelper _chartHelper;
        private IUserService _userService;
        private IService<MovieRate> _movieRateService;

        public HomeController(IService<Movie> movieService, IChartHelper chartHelper, IUserService userService, IService<MovieRate> movieRateService){
            _movieRateService = movieRateService;
            _userService = userService;
            _chartHelper = chartHelper;
            _movieService = movieService;
        }

        public ActionResult Index(){
            return View();
        }

        public ActionResult PieChart()
        {
            var movies = _movieRateService.GetAll();
            var chartData = _chartHelper.GetMovieRatesPerMonth(movies);
            var returnStream = _chartHelper.GetPieChart(chartData);
            return new FileStreamResult(returnStream, "image/png");
        }

        public PartialViewResult TopRatedList(){
            var data = _movieRateService.GetAll().OrderByDescending(m => m.Rate).Take(3);
            var vm = Mapper.Map<IQueryable<MovieRate>, IEnumerable<ListMovieRateModel>>(data);
            return PartialView(vm);
        }
        
        public PartialViewResult MovieRateList(){
            var data = _movieRateService.Find(new RatesByMonth(8));  //Hardcoded to August
            var vm = Mapper.Map<IQueryable<MovieRate>, IEnumerable<ListMovieRateModel>>(data);
            return PartialView(vm);
        }

        public ActionResult Login(){
            return PartialView("_Login");
        }
    }
}