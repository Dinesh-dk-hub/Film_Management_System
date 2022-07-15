using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data_Access_Layer
{
    public class LanguageDataAccessLayer: BaseDAL
    {
        public List<Film> GetFilmByLanguage(string lang) {
            Film f = new Film();
            List<Film> lstLanguage = new List<Film>();
                try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"select title, Release_Year, Rating from FILMS where FILMS.Language_id = (SELECT Language_id FROM LANGUAGE WHERE  CONVERT(VARCHAR, LANGUAGE.Name) = '"+lang+"')", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstLanguage.Add(new Film
                        {
                            Title = rdr.GetString("Title"),
                            ReleaseYear = rdr.GetString("Release_Year"),
                            Rating = Convert.ToInt32(rdr[2])
                        });
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstLanguage;
        }
        public List<Language> GetAllLanguages()
        {
            var lstFilms = new List<Language>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Language_id, Name FROM LANGUAGE", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstFilms.Add(new Language
                        {

                            LanguageId = rdr[0].ToString(),
                            Name = rdr[1].ToString()

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFilms;
        }
    }
    }

