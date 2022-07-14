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
                    SqlCommand cmd = new SqlCommand($"SELECT FILMS.TITLE, FILMS.RELEASE_YEAR, FILMS.RATING FROM FILMS LEFT JOIN ACTOR ON ACTOR.Actor_id = FILMS.Actor_id where CONVERT(VARCHAR, ACTOR.First_Name)= '"+name+"'", con);
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
    }
}
