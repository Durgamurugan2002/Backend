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
    public class TabletController : ControllerBase
    { 
        
        [HttpGet]
        public IActionResult Get(Guid Userid)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
            String query="select * from tab where userid='"+Userid+"'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<ProductEntity> records=new List<ProductEntity>();

            for(int i=0;i< dt.Rows.Count;i++)
            {
                ProductEntity en=new ProductEntity();
                

                en.Type= Convert.ToString(dt.Rows[i]["Type"].ToString());
                en.Tabletname= Convert.ToString(dt.Rows[i]["Tabletname"].ToString());
                en.Manufacturingname= Convert.ToString(dt.Rows[i]["Manufacturingname"].ToString());
                en.Price= Convert.ToInt32(dt.Rows[i]["Price"].ToString());
                en.Stock= Convert.ToInt32(dt.Rows[i]["Stock"].ToString());
                en.Userid= Convert.ToString(dt.Rows[i]["Userid"].ToString());
                records.Add(en);            }

             return Ok(records);

        }
 

    
        [HttpPost]
        public IActionResult Post(ProductEntity en){
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid id=Guid.NewGuid();
            String query="insert into tab values('"+id+"','"+en.Type+"','"+en.Tabletname+"','"+en.Manufacturingname+"','"+en.Price+"','"+en.Stock+"','"+en.Userid+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();
                cmd.ExecuteNonQuery();
                en.IsOk=true;
                en.Message="Product Update";
                return Ok(en);
            }
             catch(Exception ex){
                en.IsOk=false;
                en.Message=ex.Message;
                return Ok(en);
           }
        }
         

    

    
    }

}        
        

       


