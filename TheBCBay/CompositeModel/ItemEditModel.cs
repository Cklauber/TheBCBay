using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBCBay.CompositeModel
{
    public class ItemEditModel
    {
        [Required, MaxLength(25)]
        public string Title { get; set; }
        [Required, MinLength(25), MaxLength(1000)]
        public string Description { get; set; }
        //public decimal CurrentPrice { get; set; }

        [Required, Display(Name = "Initial Price")]
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TopPrice { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}"), DataType(DataType.Currency), Display(Name = "Final Price")]
        public decimal LowPrice { get; set; }

        //public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End time"), DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
    }
}
