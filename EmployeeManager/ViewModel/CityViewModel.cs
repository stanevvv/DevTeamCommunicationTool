using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityViewModel
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public CityViewModel(string name, string zipCode)
        {
            Name = name;
            ZipCode = zipCode;
        }
    }
}