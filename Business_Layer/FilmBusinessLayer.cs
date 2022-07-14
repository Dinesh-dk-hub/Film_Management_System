using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;

namespace Business_Layer
{
    public class FilmBusinessLayer
    {
     public List<Film> GetAllDetails()
        {
            List<Film> lstFilms = new List<Film>();
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            lstFilms = fal.GetAllDetails();
            return lstFilms;

        }
        public List<Film> GetFilmByRating(int rate)
        {
            Film f = new Film();
            List<Film> lstRatings = new List<Film>();
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            lstRatings = fal.GetFilmByRating(rate);
            return lstRatings;

        }
       public List<Film> GetAllFilms()
        {
            Film f = new Film();
            List<Film> lstAllFilms = new List<Film>();
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            lstAllFilms = fal.GetAllFilms();
            return lstAllFilms;

        }
        public List<Film> GetFilmByMethods(string n, string y, int g)
        {
            
            List<Film> lstMethods = new List<Film>();
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            lstMethods =  fal.GetFilmByMethods(n, y, g);
            return lstMethods;

        }
        public Film GetFilmByTitle(string t)
        {
            
            FilmDataAccessLayer fl = new FilmDataAccessLayer();
            Film f = fl.GetFilmByTitle(t);
            return f;
        }
        public bool NewMovie(Film f)
        {
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            bool d = fal.NewMovie(f);
            return d;
        }
        public bool Modify(Film f)
        {
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            bool d = fal.Modify(f);
            return d;
        }
        public bool RemoveMovie(Film f)
        {
            FilmDataAccessLayer fal = new FilmDataAccessLayer();
            bool d = fal.RemoveFilm(f);
            return d;
        }
    }
}
