using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer
{
   public class BaseDAL
    {

        public static string CnString;

        public BaseDAL()
        {
            CnString = "Data Source=DESKTOP-O2CACJJ\\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;TrustServerCertificate=true;trusted_connection=true;";

        }
    }
}
