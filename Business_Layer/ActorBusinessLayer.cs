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
    }
}
