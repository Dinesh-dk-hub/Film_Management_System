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
        public Film GetFilmByActor(string name)
        {
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
    }
}
