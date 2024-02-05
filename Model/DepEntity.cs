using Microsoft.AspNetCore.Mvc;

namespace testapi.Model{
    public class DepEntity{

    public int Price{get;set;}
    public int Year{get;set;}
    public int Scrapvalue{get;set;}
     public int Depreciation{
        get{
        return (this.Price - this.Scrapvalue)/ this.Year;
     }}



    }
}
    
        
