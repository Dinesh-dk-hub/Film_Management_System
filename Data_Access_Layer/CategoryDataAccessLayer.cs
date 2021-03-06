using Entity_Layer;
using Exception_Layer;
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
            catch (InvalidAttemptException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            return lstCategory;
        }
        public List<Category> GetAllCategory()
        {
            var lstCategory = new List<Category>();
            try
            {
                using (SqlConnection con = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstCategory.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString()

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCategory;
        }
        public bool NewCategory(Category l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into CATEGORY(Name)  values('{l.Name}')";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool ModifyCategory(Category l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"UPDATE CATEGORY  SET Name ='{l.Name}'  where Category_id={l.CategoryId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
        public bool RemoveCategory(Category l)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"DELETE FROM CATEGORY WHERE Category_id={l.CategoryId}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return true;
        }
    }
    }
    

