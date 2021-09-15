using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Client.CustomSettings
{
    public class CustomizationItem
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public int type { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
