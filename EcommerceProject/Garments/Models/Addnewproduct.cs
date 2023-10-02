using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Garments.Models
{
    public class Addnewproduct
    {
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public string shortdiscription { get; set; }
        public double Price { get; set; }
        public string PicUrl { get; set; }

        public string producttype { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }



        //adding products
        public void ADD(Addnewproduct item)
        {
            
            string query = "insert into tbl_Products values('" + item.ProductName + "','" + item.shortdiscription + "','" + item.Price + "','" + item.PicUrl + "','" + item.producttype + "') ";
            SqlCommand SC = new SqlCommand(query,Connection_cls.Get());
            SC.ExecuteNonQuery();

        }

        public void Update()
        {

            string query = "Update tbl_Products set  Product_name='" + ProductName + "',Shortdiscription ='" + shortdiscription + "',Price ='" + Price + "',Product_Image_url ='" + PicUrl + "',producttype ='" + producttype + "' where Product_ID ='" + Product_ID + "'";
            SqlCommand SC = new SqlCommand(query, Connection_cls.Get());
            SC.ExecuteNonQuery();

        }

        public void Delete ()
        {

            string query = "Delete tbl_Products Where Product_ID ='" + Product_ID + "'";
            SqlCommand SC = new SqlCommand(query, Connection_cls.Get());
            SC.ExecuteNonQuery();

        }



        public Addnewproduct Search()
        {
            string query = "SELECT * FROM tbl_Products WHERE Product_ID = '" + Product_ID + "'";
            SqlCommand SC = new SqlCommand(query, Connection_cls.Get());
            SC.ExecuteNonQuery();
            Addnewproduct pdct = new Addnewproduct();
            SqlDataReader sdr = SC.ExecuteReader();
            while (sdr.Read())
            {
                pdct.Product_ID = Convert.ToInt32(sdr["Product_ID"]);
                pdct.ProductName = sdr["Product_name"].ToString();
                pdct.shortdiscription = sdr["shortdiscription"].ToString();
                pdct.Price = Convert.ToDouble(sdr["Price"]);
                pdct.PicUrl = sdr["Product_Image_url"].ToString();
                pdct.producttype = sdr["producttype"].ToString();


            }
            sdr.Close();
            return pdct;
        }

        //search byt producttype
        public List<Addnewproduct> Searchproducttype(string producttype)
        {
            List<Addnewproduct> productlst = new List<Addnewproduct>();
            string constring = @"Data Source=DESKTOP-KEER69S\SQLEXPRESS;Initial Catalog=CartProducts;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Products WHERE producttype = '" + producttype + "'");
            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.Connection = sqlcon;
            sqlcon.Open();
            sda.SelectCommand = cmd;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Addnewproduct pdct = new Addnewproduct();
                pdct.Product_ID = Convert.ToInt32(sdr["Product_ID"]);
                pdct.ProductName = sdr["Product_name"].ToString();
                pdct.shortdiscription = sdr["shortdiscription"].ToString();
                pdct.Price = Convert.ToDouble(sdr["Price"]);
                pdct.PicUrl = sdr["Product_Image_url"].ToString();
                pdct.producttype = sdr["producttype"].ToString();
                productlst.Add(pdct);
            }
            sdr.Close();
            sqlcon.Close();
            return productlst;

        }


        public List<Addnewproduct> productlist()
        {
            List<Addnewproduct> pdctlst = new List<Addnewproduct>();
            string constring = @"Data Source=DESKTOP-KEER69S\SQLEXPRESS;Initial Catalog=CartProducts;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("select * from tbl_products");
            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.Connection = sqlcon;
            sqlcon.Open();
            sda.SelectCommand = cmd;
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                Addnewproduct pdct = new Addnewproduct();
                pdct.Product_ID = Convert.ToInt32(sdr["Product_ID"]);
                pdct.ProductName = sdr["Product_name"].ToString();
                pdct.shortdiscription = sdr["shortdiscription"].ToString();
                pdct.Price = Convert.ToDouble(sdr["Price"]);
                pdct.PicUrl = sdr["Product_Image_url"].ToString();
                pdct.producttype = sdr["producttype"].ToString();
                pdctlst.Add(pdct);
            }
            sdr.Close();
            sqlcon.Close();
            return pdctlst;

        }
    }


    
}