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
    public class TransactionController : ControllerBase
    {  
[HttpPost]
        public IActionResult Post(TransEntity entity)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid id=Guid.NewGuid();
            String query="insert into trans values('"+id+"','"+entity.Userid+"','"+entity.Tabletid+"','"+entity.Quantity+"','"+entity.Amount+"','"+entity.Total+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();

                string que ="select * from tab where id='"+entity.Tabletid+"'";
                SqlDataAdapter da1=new SqlDataAdapter(que,con);
                DataTable dt1=new DataTable();
                da1.Fill(dt1);
                if(dt1.Rows.Count==1){
                      long dataBaseStock =  Convert.ToInt64(dt1.Rows[0]["Stock"].ToString());
                long netQuantity = dataBaseStock -Convert.ToInt32(entity.Quantity);
                string que1="update tab set stock='"+netQuantity+"' where id='"+dt1.Rows[0]["Id"].ToString()+"'";
                Console.WriteLine(que);
                SqlCommand cmd1=new SqlCommand(que1,con);
                cmd1.ExecuteNonQuery();
                }

                cmd.ExecuteNonQuery();
                return Ok(entity);
            }
             catch(Exception ex){
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid Userid)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
            String query="select * from trans where userid='"+Userid+"'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<TransEntity> records=new List<TransEntity>();

            for(int i=0;i< dt.Rows.Count;i++)
            {
                TransEntity en=new TransEntity();

                en.Tabletid=dt.Rows[i]["Tabletid"].ToString();
                en.Quantity= dt.Rows[i]["Quantity"].ToString();
                en.Amount= dt.Rows[i]["Amount"].ToString();
                 en.Userid= dt.Rows[i]["Userid"].ToString();
                  en.Total=(Convert.ToDouble(dt.Rows[i]["Quantity"].ToString())*Convert.ToDouble(dt.Rows[i]["Amount"].ToString())).ToString();
                records.Add(en);            }

             return Ok(records);
        }
         
    }

      
}

       


