using Microsoft.AspNetCore.Mvc;
using testapi.Model;
namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
       
        public TestController()
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
         //[HttpPost]
         //public IActionResult calculate(Entity entity){
             //entity.pay = entity.Basic+entity.Da+entity.Hra;
             //entity.Presentpay=entity.pay/(entity.Presentdays+1);
             //entity.Pf=(entity.pay*entity.Pf)/100;
             //entity.Esi=(entity.pay*entity.Esi)/100;
             //entity.Otherpay=(entity.Medical+entity.Otherallowance)/(entity.Presentdays+1);
             //entity.netPay=(entity.presentPay+entity.otherPay)-(entity.PF+entity.ESI);
            
                    // return  Ok(entity);
         //}

        }
}
