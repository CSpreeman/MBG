using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITM.Models
{
    public class ItemModel<T> : Base
    {
        public T Item { get; set; }   
    }
}