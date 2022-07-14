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
        public List<Film> GetFilmByCategory(string category) {
            List<Film> lstCategory = new List<Film>();
            Film f = new Film();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT FILMS.TITLE, FILMS.RELEASE_YEAR, FILMS.RATING FROM FILMS LEFT JOIN CATEGORY ON CATEGORY.Category_id = FILMS.Category_id where CONVERT(VARCHAR, CATEGORY.Name)= '" + category + "'", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstCategory.Add(new Film {
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
            return lstCategory;
        }
    }
    }
    

