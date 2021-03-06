using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class LanguageBusinessLayer
    {
        public List<Film> GetFilmByLanguage(string lang)
        {
            Film f = new Film();
            List<Film> lstLanguage = new List<Film>();
            LanguageDataAccessLayer fal = new LanguageDataAccessLayer();
            lstLanguage = fal.GetFilmByLanguage(lang);
            return lstLanguage;

        }

        public List<Language> GetAllLanguages()
        {
            List<Language> lstLangs = new List<Language>();
            LanguageDataAccessLayer l = new LanguageDataAccessLayer();
            lstLangs = l.GetAllLanguages();
            return lstLangs;
        }
        public bool NewLanguage(Language l)
        {

            LanguageDataAccessLayer al = new LanguageDataAccessLayer();
            bool t = al.NewLanguage(l);
            return t;
        }
        public bool ModifyLanguage(Language l)
        {
            LanguageDataAccessLayer al = new LanguageDataAccessLayer();
            bool g = al.ModifyLanguage(l);
            return g;
        }
        public bool RemoveLanguage(Language l)
        {
            LanguageDataAccessLayer al = new LanguageDataAccessLayer();
            bool k = al.RemoveLanguage(l);
            return k;
        }
    }
}
