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
        /*       private readonly IConfiguration _configuration;
               private readonly string _connectionString;
               public FilmDataAccessLayer(IConfiguration configuration)
               {
                   this._configuration = configuration;
                   this._connectionString = this._configuration.GetConnectionString("DefaultConnection");
               }*/
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
                            ReleaseYear = rdr.GetDateTime("Release_Year"),
                            LanguageId = Convert.ToInt32(rdr[4]),
                            OriginalLanguageId = Convert.ToInt32(rdr[5]),
                            RentalDuration = rdr.GetDateTime("Rental_duration"),
                            Length = Convert.ToInt32(rdr[7]),
                            ReplacementCost = Convert.ToInt32(rdr[8]),
                            Rating = Convert.ToInt32(rdr[9]),
                            SpecialFeatures = rdr.GetString("Special_features"),
                            ActorId = Convert.ToInt32(rdr[11]),
                            CategoryId = Convert.ToInt32(rdr[12])


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
                        f.ReleaseYear = rdr.GetDateTime("Release_Year");
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
        public Film GetFilmByRating(int rate)
        {

            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Title, Release_Year, Rating FROM FILMS WHERE Rating = {rate}  ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        f.Title = rdr.GetString("Title");
                        f.ReleaseYear = rdr.GetDateTime("Release_Year");
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
                            ReleaseYear = rdr.GetDateTime("Release_Year"),
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
        public Film GetFilmByMethods(string t, string year, int rate)
        {

            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Title, Release_Year, Rating FROM FILMS WHERE (CONVERT(VARCHAR, Title) = '{t}' AND Rating = {rate} AND Release_Year = {year}) ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        f.Title = rdr.GetString("Title");
                        f.ReleaseYear = rdr.GetDateTime("Release_Year");
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



    } }
