using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using testapi.Model;
using System.Data;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
       [HttpGet]
        public IActionResult Get(int Cardno,string Cardname,string Expirymonthyear,int Cvcno,int Amount)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
        String query="select * from pay where Cardno='"+Cardno+"'and Cardname='"+Cardname+"'and Expirymonthyear='"+Expirymonthyear+"'and Cvcno='"+Cvcno+"'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            BaseEntity en=new BaseEntity();

            if(dt.Rows.Count==1)
            {
                long dataBaseAmount =  Convert.ToInt64(dt.Rows[0]["Amount"].ToString());
                long netAmount = dataBaseAmount - Amount;
                string que="update pay set amount='"+netAmount+"' where id='"+dt.Rows[0]["Id"].ToString()+"'";
                Console.WriteLine(que);
                SqlCommand cmd=new SqlCommand(que,con);
                cmd.ExecuteNonQuery();

                en.IsOk=true;
                en.Message="Payment Successfully";
            }
            else
            {
             en.IsOk=false;
             en.Message="Invalid credertial";
             }
               return Ok(en);
            
        }
    }

}        
        

       


