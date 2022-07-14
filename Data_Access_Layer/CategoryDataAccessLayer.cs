using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data_Access_Layer
{
    public class CategoryDataAccessLayer: BaseDAL
    {
        public Film GetFilmByCategory(string category) {
            
            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT FILMS.TITLE, FILMS.RELEASE_YEAR, FILMS.RATING FROM FILMS LEFT JOIN CATEGORY ON CATEGORY.Category_id = FILMS.Category_id where CONVERT(VARCHAR, CATEGORY.Name)= '" + category + "'", con);
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
    

