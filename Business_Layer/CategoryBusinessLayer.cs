using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class CategoryBusinessLayer
    {
        public List<Film> GetFilmByCategory(string g)
        {
            Film f = new Film();
            List<Film> lstCategory = new List<Film>();
            CategoryDataAccessLayer fal = new CategoryDataAccessLayer();
            lstCategory = fal.GetFilmByCategory(g);
            return lstCategory;

        }
        public List<Category> GetAllCategory()
        {
            List<Category> lstCategory = new List<Category>();
            CategoryDataAccessLayer l = new CategoryDataAccessLayer();
            lstCategory = l.GetAllCategory();
            return lstCategory;
        }
        public bool NewCategory(Category l)
        {

            CategoryDataAccessLayer al = new CategoryDataAccessLayer();
            bool t = al.NewCategory(l);
            return t;
        }
        public bool ModifyCategory(Category l)
            
        {
            CategoryDataAccessLayer al = new CategoryDataAccessLayer();
            bool g = al.ModifyCategory(l);
            return g;
        }
        public bool RemoveCategory(Category l)
        {
            CategoryDataAccessLayer al = new CategoryDataAccessLayer();
            bool k = al.RemoveCategory(l);
            return k;
        }
    }
}
