using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Sample.DataAccess.Entities;
using Sample.Service.EntityServices;
using Sample.Web.ViewModels.Movie;

namespace Sample.Web.Controllers{
    public class MoviesController : BaseController{
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public MoviesController(IMovieService movieService, IUserService userService){
            _userService = userService;
            _movieService = movieService;
        }

        public ActionResult Index(){
            var data = _movieService.GetAll();
            var vm = Mapper.Map<IQueryable<Movie>, IEnumerable<ListMovieModel>>(data);
            return View(vm);
        }

        public ActionResult Create(){
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(CreateMovieModel movie){
            if (!ModelState.IsValid)
                //return PartialView("_Create", movie);
                return RedirectToAction("Index");

            try{
                var entity = new Movie(){
                    Id = Guid.NewGuid(),
                    Title = movie.Title,
                    Date = DateTime.Now
                };

                _movieService.Add(entity);
                _movieService.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception){
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult Edit(Guid id){
            var entity = _movieService.GetById(id);

            if (entity == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var vm = Mapper.Map<Movie, EditMovieModel>(entity);

            return PartialView("_Edit", vm);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditMovieModel movie){
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var entity = _movieService.GetById(id);
            if (entity == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            entity.Title = movie.Title;

            try{
                _movieService.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception){
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid id){
            var entity = _movieService.GetById(id);
            if (entity == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return PartialView("_Delete", entity);
        }

        [HttpPost]
        public ActionResult Delete(Guid id){
            var entity = _movieService.GetById(id);

            if (entity == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            try{
                _movieService.Remove(entity);
                _movieService.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception){
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}