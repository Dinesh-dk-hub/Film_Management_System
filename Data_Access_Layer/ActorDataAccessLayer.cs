using Entity_Layer;
using System;
using Exception_Layer;
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
            name = name.Replace(" ", "");

            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"select title, Release_Year, Rating from FILMS where FILMS.Actor_id IN(SELECT Actor_id FROM ACTOR WHERE(ACTOR.First_Name LIKE '"+name+"' Or CONCAT(FIRST_NAME, LAST_NAME) Like '"+name.Trim()+"'))", con);
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
            catch (InvalidAttemptException ex)
            {
                Console.WriteLine(ex.Message);
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

                            ActorId = Convert.ToInt32(rdr[0]),
                            FirstName = rdr[1].ToString(),
                            LastName = rdr[2].ToString()

                        }) ;
                    }
                }
            }
            catch (InvalidAttemptException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lstActor;
        }
        public bool NewActor(Actor a)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into ACTOR(First_Name, Last_Name)  values('{a.FirstName}','{a.LastName}')";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool ModifyActor(Actor a)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"UPDATE ACTOR  SET First_Name ='{a.FirstName}' ,Last_Name ='{a.LastName}' where Actor_id={a.ActorId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
       public bool RemoveActor(int ActorId)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"DELETE FROM ACTOR WHERE Actor_id={ActorId};";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
    }
}
