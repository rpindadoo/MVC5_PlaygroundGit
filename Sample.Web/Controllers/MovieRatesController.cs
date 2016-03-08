using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Sample.DataAccess.Entities;
using Sample.Service.Core;
using Sample.Service.EntityServices;
using Sample.Web.ViewModels.Movie;
using Sample.Web.ViewModels.MovieRate;

namespace Sample.Web.Controllers{
    public class MovieRatesController : BaseController{
        private readonly IMovieRateService _movieRateService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public MovieRatesController(IMovieRateService movieRateService, IUserService userService, IMovieService movieService){
            _movieService = movieService;
            _userService = userService;
            _movieRateService = movieRateService;
        }

        public ActionResult Create(Guid id){
            var movie = _movieService.GetById(id);
            if (movie == null)
                return RedirectToAction("Index", "Movies");

            var guest = _userService.GetAll().FirstOrDefault(u => u.Firstname.Contains("Guest"));
            if (guest == null)
                return RedirectToAction("Index", "Movies");

            var movieRate = new CreateMovieRateModel{UserId = guest.Id, MovieId = id};
            return PartialView("_Create", movieRate);
        }

        [HttpPost]
        public ActionResult Create(CreateMovieRateModel movie){
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Movies");

            try{
                var entity = new MovieRate(){
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Rate = movie.Rate,
                    Comments = movie.Comments,
                    UserId = movie.UserId,
                    MovieId = movie.MovieId
                };

                _movieRateService.Add(entity);
                _movieRateService.SaveChanges();
                return RedirectToAction("Index", "Movies");
            } catch (Exception){
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid id){
            var entity = _movieRateService.GetById(id);

            if (entity == null)
                return RedirectToAction("Index", "Movies");

            return PartialView("_ConfirmDelete", entity);
        }

        [HttpPost]
        public ActionResult Delete(Guid id){
            var entity = _movieRateService.GetById(id);

            if (entity == null)
                return RedirectToAction("Index", "Movies");

            try{
                _movieRateService.Remove(entity);
                _movieRateService.SaveChanges();
                return RedirectToAction("Index", "Movies");
            } catch (Exception){
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}