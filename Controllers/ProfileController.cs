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
    public class ProfileController : ControllerBase
    { 
         [HttpGet]
        public IActionResult Get(Guid Userid)
        {
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            con.Open();
            String query="select * from profile where userid='"+Userid+"'";
            SqlDataAdapter da=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<ProfileEntity> records=new List<ProfileEntity>();

            for(int i=0;i< dt.Rows.Count;i++)
            {
                ProfileEntity en=new ProfileEntity();
                

                en.Firstname= Convert.ToString(dt.Rows[i]["Firstname"].ToString());
                en.Lastname= Convert.ToString(dt.Rows[i]["Lastname"].ToString());
                en.Dateofbirth= Convert.ToString(dt.Rows[i]["Dateofbirth"].ToString());
                en.Gender= Convert.ToString(dt.Rows[i]["Gender"].ToString());
                en.Address= Convert.ToString(dt.Rows[i]["Address"].ToString());
                en.Userid= Convert.ToString(dt.Rows[i]["Userid"].ToString());
                records.Add(en);            }

             return Ok(records);
            }

        [HttpPost]
        public IActionResult Post(ProfileEntity en){
            SqlConnection con=new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Database=test;Integrated Security=True;");
            Guid id=Guid.NewGuid();
            String query="insert into profile values('"+id+"','"+en.Firstname+"','"+en.Lastname+"','"+en.Dateofbirth+"','"+en.Gender+"','"+en.Address+"','"+en.Userid+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            try{
                con.Open();
                cmd.ExecuteNonQuery();
                en.IsOk=true;
                en.Message="Profile saved";
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
        

       


