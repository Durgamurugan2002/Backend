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
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string Email,string Password)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
        String query="select * from log where Email='"+Email+"' and Password='"+Password+"'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            BaseEntity en=new BaseEntity();

            if(dt.Rows.Count==1)
            {
                en.IsOk=true;
                en.Message=dt.Rows[0][0].ToString();
            }
            else
            {
             en.IsOk=false;
             en.Message="Invalid credertial";
             }
               return Ok(en);
            
        }
           
                     
        [HttpPost]
        public IActionResult Post(RegisterEntity en){
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid id=Guid.NewGuid();
            String query="insert into log values('"+id+"','"+en.Name+"','"+en.Email+"','"+en.Password+"','"+en.Location+"','"+en.Role+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();
                cmd.ExecuteNonQuery();
                en.IsOk=true;
                en.Message="Registered Successfully";
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
        

       


