using Microsoft.AspNetCore.Mvc;

namespace testapi.Model{
    public class PaymentEntity:BaseEntity
    {

    public int Cardno{get;set;}
    public string Cardname{get;set;}
    public string Expirymonthyear{get;set;}
    public int Cvcno{get;set;}
    public int Amount{get;set;}
     


    }
}
    
        
