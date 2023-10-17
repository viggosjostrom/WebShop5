using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;
public record Product(string Name, int Price)
{
    public string ToCSVString()
    {
        return $"{Name},{Price}";
    }
}