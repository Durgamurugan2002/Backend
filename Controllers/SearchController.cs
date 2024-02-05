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
    public class SearchController : ControllerBase
    {

         [HttpGet]
        public IActionResult Get(string searchText)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
            String query="select * from tab  INNER JOIN log ON log.id=tab.userid where tab.Tabletname like '%"+searchText+"%'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<SearchEntity> records=new List<SearchEntity>();

             for(int i=0;i< dt.Rows.Count;i++)
            {
                SearchEntity en=new SearchEntity();

                en.Type= Convert.ToString(dt.Rows[i]["Type"].ToString());
                en.Tabletname= Convert.ToString(dt.Rows[i]["Tabletname"].ToString());
                en.Id= Convert.ToString(dt.Rows[i]["Id"].ToString());
                en.Manufacturingname= Convert.ToString(dt.Rows[i]["Manufacturingname"].ToString());
                en.Price= Convert.ToInt32(dt.Rows[i]["Price"].ToString());
                en.Qty=0;
                en.Stock= Convert.ToInt32(dt.Rows[i]["Stock"].ToString());
                en.Userid= Convert.ToString(dt.Rows[i]["Userid"].ToString());
                en.Name=Convert.ToString(dt.Rows[i]["Name"].ToString());
                 en.Location=Convert.ToString(dt.Rows[i]["Location"].ToString());
                records.Add(en);            }

             return Ok(records);

        }
 

    
    
        
           

           
               
            
        
           
                     
        
    }

}        
        

       


