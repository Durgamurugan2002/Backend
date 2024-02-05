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
    public class DepController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
            String query="select * from dep";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<DepEntity> records=new List<DepEntity>();

            for(int i=0;i< dt.Rows.Count;i++)
            {
                DepEntity en=new DepEntity();

                en.Price= Convert.ToInt32(dt.Rows[i]["Price"].ToString());
                en.Year= Convert.ToInt32(dt.Rows[i]["Year"].ToString());
                en.Scrapvalue= Convert.ToInt32(dt.Rows[i]["Scrapvalue"].ToString());
                records.Add(en);            }

             return Ok(records);

        }
 

        [HttpPost]
        public IActionResult Post(DepEntity entity)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid id=Guid.NewGuid();
            String query="insert into dep values('"+id+"','"+entity.Price+"','"+entity.Year+"','"+entity.Scrapvalue+"','"+entity.Depreciation+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();
                cmd.ExecuteNonQuery();
                return Ok(entity);
            }
             catch(Exception ex){
                return Ok(ex.Message);
            }
        }
    }

}        
        

       


