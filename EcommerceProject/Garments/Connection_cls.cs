using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Garments
{
    public class Connection_cls
    {
        public static SqlConnection Sc ;
        public static SqlConnection Get()
        {
            if (Sc == null)
            {
                Sc = new SqlConnection();
                Sc.ConnectionString = @"server=DESKTOP-KEER69S\SQLEXPRESS;database=CartProducts;Integrated Security=True";
                Sc.Open();

            }
            return Sc;

        }

    }
}