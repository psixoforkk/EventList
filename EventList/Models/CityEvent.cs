using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventList.Models
{
    public class CityEvent
    {
        public string Title1 { get; set; }
        public string Ddescription { get; set; }
        public string Ddate { get; set; }
        public string Ccategory { get; set; }
        public string Price { get; set; }
        public CityEvent()
        {
            Title1= string.Empty;
            Ddescription= string.Empty; 
            Ddate= string.Empty;    
            Ccategory = string.Empty;
            Price= string.Empty;    
            ImagePath= string.Empty;
        }
        public string ImagePath { get; set; }

    }
}
