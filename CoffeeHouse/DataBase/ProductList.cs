//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeHouse.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductList
    {
        public int IDProductList { get; set; }
        public int IDProduct { get; set; }
        public int IDCheck { get; set; }
        public int Quantity { get; set; }
    
        public virtual Check Check { get; set; }
        public virtual Product Product { get; set; }
    }
}
