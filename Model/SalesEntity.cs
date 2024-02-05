using Microsoft.AspNetCore.Mvc;

namespace testapi.Model{
    public class SalesEntity{
    
    public string ProductName{get;set;}
    public double Price{get;set;}
    public double Quantity{get;set;}
    public int TaxPercentage{get;set;}
    public bool IsTax{get;set;}
     public double Total{
        get{
            return this.Price*this.Quantity;
        }
     }
     public double TaxAmount
     {
        get{
            return(this.Total*this.TaxPercentage)/100;
        }

     }
     public double NetAmount{
        get{
            return this.IsTax==true?(this.TaxAmount+this.Total):this.Total;
        }
     }

    }
}
