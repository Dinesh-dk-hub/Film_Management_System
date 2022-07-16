using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class ActorBusinessLayer
    {
        public List<Film> GetFilmByRating(string e)
        {
            Film f = new Film();
            List<Film> lstActor = new List<Film>();
            ActorDataAccessLayer fal = new ActorDataAccessLayer();
            lstActor = fal.GetFilmByActor(e);
            return lstActor;

        }
        public List<Actor> GetAllActors()
        {
            List<Actor> lstActors = new List<Actor>();
            ActorDataAccessLayer l = new ActorDataAccessLayer();
            lstActors = l.GetAllActors();
            return lstActors;
        }
        public bool NewActor(Actor a)
        {
           
            ActorDataAccessLayer al = new ActorDataAccessLayer();
            bool t = al.NewActor(a);
            return t;
        }
        public bool ModifyActor(Actor a)
        {
            ActorDataAccessLayer al = new ActorDataAccessLayer();
            bool g = al.ModifyActor(a);
            return g;
        }
        public bool RemoveActor(Actor a)
        {
            ActorDataAccessLayer al = new ActorDataAccessLayer();
            bool l = al.RemoveActor(a);
            return l;
        }
    }
}
