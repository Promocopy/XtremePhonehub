using System;
using System.ComponentModel.DataAnnotations;

namespace XtremePhonehub.Entity
{
    public class XtremeDetails
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specification { get; set; }
        public int Quantity { get; set; }
        public int BuyingPrice { get; set; }
        public int SellingPrice { get; set; }
        public DateTime ExpiryDate { get; set; }


    }
}
