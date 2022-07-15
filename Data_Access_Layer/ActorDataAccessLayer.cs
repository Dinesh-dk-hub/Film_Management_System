using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data_Access_Layer
{
    public class ActorDataAccessLayer: BaseDAL
    {
        public List<Film> GetFilmByActor(string name)
        {
            List<Film> lstActor = new List<Film>();
            Actor a = new Actor();
            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"select title, Release_Year, Rating from FILMS where FILMS.Actor_id = (SELECT Actor_id FROM ACTOR WHERE  CONVERT(VARCHAR, ACTOR.First_Name) = '"+name+"')", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstActor.Add(new Film
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
            return lstActor;
        }
        public List<Actor> GetAllActors()
        {
            var lstActor = new List<Actor>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Actor_id, First_Name, Last_Name FROM ACTOR", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstActor.Add(new Actor
                        {

                            ActorId = rdr[0].ToString(),
                            FirstName = rdr[1].ToString(),
                            LastName = rdr[2].ToString()

                        }) ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstActor;
        }
    }
}
