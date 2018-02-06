using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBCBay.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal TopPrice { get; set; }
        public decimal LowPrice { get; set; }
        public int UsrId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        //Add Photos

    }
}
