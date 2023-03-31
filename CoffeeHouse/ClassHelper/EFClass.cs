using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.DataBase;

namespace CoffeeHouse.ClassHelper
{
    public class EFClass
    {
        public static Entities5 Context { get;} = new Entities5();
    }
}
