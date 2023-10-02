using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Garments.Models
{
    public class signup_cls
    {
        public int Account_ID { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }


        public string Gender { get; set; }

        public int Phone { get; set; }

        public string Password { get; set; }

        public string RetypePassword { get; set; }

        public string Usertype { get; set; }        //data from which mart : name   like chaseup
        
        
        public void ADD(signup_cls signupdata)
        {
            signupdata.Usertype = "vendor";
            string query = "INSERT INTO [CartProducts].[dbo].[tbl_signup]([Username],[Nickname],[Email],[Firstname],[Lastname],[Gender],[Phone],[Password],[RetypePassword],[Usertype])VALUES('" + signupdata.Username + "','" + signupdata.Nickname + "','" + signupdata.Email + "','" + signupdata.Firstname + "','" + signupdata.Lastname + "','" + signupdata.Gender + "','" + signupdata.Phone + "','" + signupdata.Password + "','" + signupdata.RetypePassword + "','" + signupdata.Usertype + "') ";
            SqlCommand SC = new SqlCommand(query, Connection_cls.Get());
            SC.ExecuteNonQuery();

        }



        public List<signup_cls> Getuserandpass()
        {
            List<signup_cls> acclist = new List<signup_cls>();
            string constring = @"Data Source=DESKTOP-KEER69S\SQLEXPRESS;Initial Catalog=CartProducts;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_signup");
            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.Connection = sqlcon;
            sqlcon.Open();
            sda.SelectCommand = cmd;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                signup_cls sgn = new signup_cls();
                sgn.Username = sdr["Username"].ToString();
                sgn.Password = sdr["Password"].ToString();
                sgn.Account_ID = Convert.ToInt32(sdr["Account_ID"]);
                acclist.Add(sgn);
            }
            sdr.Close();
            sqlcon.Close();
            return acclist;


        }
    }
}