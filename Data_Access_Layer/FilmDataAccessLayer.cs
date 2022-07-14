using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entity_Layer;

namespace Data_Access_Layer
{

    public class FilmDataAccessLayer : BaseDAL
    {
      
        public List<Film> GetAllDetails()
        {
            var lstFilms = new List<Film>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM FILMS", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstFilms.Add(new Film
                        {
                            FilmId = Convert.ToInt32(rdr[0]),
                            Description = rdr.GetString("Description"),
                            Title = rdr.GetString("Title"),
                            ReleaseYear = rdr[3].ToString(),
                            LanguageId = Convert.ToInt32(rdr[4]),
                            OriginalLanguageId = Convert.ToInt32(rdr[5]),
                            RentalDuration = rdr[6].ToString(),
                            Length = Convert.ToInt32(rdr[7]),
                            ReplacementCost = Convert.ToInt32(rdr[8]),
                            Rating = Convert.ToInt32(rdr[9]),
                            SpecialFeatures = rdr.GetString("Special_features"),
                            ActorId = Convert.ToInt32(rdr[11]),
                            CategoryId = Convert.ToInt32(rdr[12])


                        }) ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFilms;
        }

        public Film GetFilmByTitle(string t)
        {
         
            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Title, Release_Year, Rating FROM FILMS WHERE CONVERT(VARCHAR, Title) = '"+t+"'  ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        f.Title = rdr.GetString("Title");
                        f.ReleaseYear = rdr.GetString("Release_Year");
                        f.Rating = Convert.ToInt32(rdr[2]);

                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return f;
        }
        public List<Film> GetFilmByRating(int rate)
        {
            Film f = new Film();
            List<Film> lstratings = new List<Film>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Title, Release_Year, Rating FROM FILMS WHERE Rating = {rate}  ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstratings.Add(new Film
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
            return lstratings;
        }
        public List<Film> GetAllFilms()
        {
            var lstFilms = new List<Film>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Title, Release_Year, Rating FROM FILMS", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstFilms.Add(new Film
                        {
                      
                            Title = rdr.GetString("Title"),
                            ReleaseYear = rdr.GetString("Release_Year"),
                            Rating = Convert.ToInt32(rdr[2]),
                     

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
        public List<Film> GetFilmByMethods(string t, string year, int rate)
        {
            List<Film> lstMethods = new List<Film>();
            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Title, Release_Year, Rating FROM FILMS WHERE (CONVERT(VARCHAR, Title) = '{t}' AND Rating = {rate} AND Release_Year = {year}) ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstMethods.Add(new Film {
                            Title = rdr.GetString("Title"),
                        ReleaseYear = rdr.GetString("Release_Year"),
                        Rating = Convert.ToInt32(rdr[2]),
                    });
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lstMethods;
        }

        public bool NewMovie(Film fil)
        {

            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into FILMS(Description,Title,Language_id,Original_language_id,Length,Replacement_Cost,Rating,Special_Features,Actor_id,Category_id,Release_Year,Rental_Duration)  values('{fil.Description}','{fil.Title}','{fil.LanguageId}','{fil.OriginalLanguageId}', {fil.Length},{fil.ReplacementCost},{fil.Rating},'{fil.SpecialFeatures}',{fil.ActorId},{fil.CategoryId},'{fil.ReleaseYear}','{fil.RentalDuration}')";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool Modify(Film fil)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"UPDATE FILMS  SET Title ='{fil.Title}' ,Release_Year ='{fil.ReleaseYear}',Rating = '{fil.Rating}' where Film_id={fil.FilmId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool RemoveFilm(Film fil)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"DELETE FROM FILMS WHERE Film_id={fil.FilmId};";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }

    }
}
