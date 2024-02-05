using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System;
namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlController : ControllerBase
    {
        
        [HttpGet("{price}/{year}/{scrapvalue}")]
        public IActionResult Get(string price,string year,string scrapvalue){
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid depreciation=Guid.NewGuid();
            String query="insert into dep values('"+price+"','"+year+"','"+scrapvalue+"','"+depreciation+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();
                cmd.ExecuteNonQuery();
                return Ok("SUCCESS");
            }
            catch(Exception ex){
                return Ok(ex.Message);
            }
            }
            }
}

