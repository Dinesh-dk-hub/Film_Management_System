using Entity_Layer;
using System;
using Exception_Layer;
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
            catch (InvalidAttemptException ex)
            {
                Console.WriteLine(ex.Message);
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

                            LanguageId = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString()

                        });
                    }
                }
            }
            catch (InvalidAttemptException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return lstFilms;
        }
        public bool NewLanguage(Language l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into LANGUAGE(Name)  values('{l.Name}')";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool ModifyLanguage(Language l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"UPDATE LANGUAGE  SET Name ='{l.Name}'  where Language_id={l.LanguageId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool RemoveLanguage(Language l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"DELETE FROM LANGUAGE WHERE Language_id={l.LanguageId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
    }
    }

