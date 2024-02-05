using Microsoft.AspNetCore.Mvc;
using testapi.Model;
namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
       
        public SalesController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("mrsdk");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            return Ok("id");
        }
        // [HttpPost]
        // public IActionResult calculate(Entity entity){
            // entity.Total = entity.M1+entity.M2+entity.M3+entity.M4;
           // entity.Avg = entity.Total/4;
            //if(entity.Avg>=80){
              //  entity.Grd="A";
            //}
            //else if(entity.Avg>=50 && entity.Avg <80){
               // entity.Grd="B";
            //}
             //else{
               // entity.Grd="C";
            //}
            
                   // return  Ok(entity);
       //}
        [HttpPost]
        public IActionResult calculate(SalesEntity entity){
            
            return Ok(entity);

        }
             
}
}

